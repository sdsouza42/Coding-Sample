from ctypes import *

lib1 = CDLL('libenc.so')
lib2 = CDLL('librev.so')

text = raw_input('Text to process: ')

lib1.ProcessBuffer(text, len(text))
lib2.ProcessBuffer(text, len(text))

print 'Processed text :',text


