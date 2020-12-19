from PIL import Image, ImageDraw, ImageFilter
import array
from math import *

img = Image.new('RGBA', (720, 1280), 'white')
idraw = ImageDraw.Draw(img)
im = Image.open("bitmap1.png")

longitude = array.array('i', [50, 200, 350, 500])
latitude = array.array('i', [60, 220, 440, 880])
x = 0
y = 0
for b in range(0, len(latitude)):
    img.paste(im, (latitude[x], longitude[y]))
    x=x+1
    y=y+1
x = 0
y = 0

img.save('map2.png')