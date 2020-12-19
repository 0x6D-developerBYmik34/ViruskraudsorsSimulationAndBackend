import socket
import mariadb
import rsa

# create pub and priv key
(pubkey, privkey) = rsa.newkeys(512)

# connect to mysql
conn = mariadb.connect(user="admin", password="raspberry", host="localhost", database="iTsar")
cur = conn.cursor()

# create socket
sock = socket.socket()
sock.bind(('', 12340))
sock.listen(1) # limit socket listen

while True:
    user, addr = sock.accept()
    user.send(pubkey.save_pkcs1())
    print('connected:', addr)
    data = user.recv(4096)


    data = rsa.decrypt(data, privkey).decode
    print (data)

    auth_key, get_id, get_passwd, get_dangerous, get_latitude, get_longitude = data.split(";")
    get_dangerous = int(get_dangerous)
    get_latitude = float(get_latitude)
    get_longitude = float(get_longitude)

    print(get_id)
    print(get_passwd)
    print(get_dangerous)
    print(get_latitude)
    print(get_longitude)

    if(auth_key == "idb8266"):
        reg = "SELECT passwd FROM `Users` WHERE id LIKE "+get_id
        cur.execute(reg, get_id)
        ok = cur.fetchone()

        if ok is not None:
            print("sign in = ok")
        else:
            row = (get_id, get_passwd, get_dangerous, get_latitude, get_longitude)
            add = "INSERT INTO Users (id, passwd, dangerous, latitude, longitude) VALUES (%s, %s, %s, %s, %s)"
            cur.execute(add, row)
            conn.commit()
            print("register = ok")
            user.send(b'Response')
    else:
        print("error(attack)")
        user.send(b'Response')