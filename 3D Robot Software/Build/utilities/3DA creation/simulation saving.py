#the bulk is about 3dr software and hopefully as much can be done as automatically as possible
#The software should be able to generate as much instructions and help out as much in that stage as possible
#However sometimes the user will have to make actions in the simulator (blender or whatever) and save them
#This script facilitates that
#the 3dr interacts with this because it can do alot then the user can do a little then it can do some more both can work together
#With all sacrifices it must Work and be parametric with our options
import bpy
import math
import os

bpy.ops.object.select_all(action='DESELECT')
ob = bpy.data.objects['connector end']
ob.select = True
bpy.context.scene.objects.active = ob

currentparent = ob.parent
bpy.ops.object.parent_clear(type = 'CLEAR_KEEP_TRANSFORM')

print(str(ob.location));
print(str(math.degrees(ob.rotation_euler.x)) + ', ' + str(math.degrees(ob.rotation_euler.y)) + ', ' + str(math.degrees(ob.rotation_euler.z)));

currentparent.select = True
bpy.context.scene.objects.active = currentparent
bpy.ops.object.parent_set(type = 'OBJECT', xmirror = False, keep_transform = True)
