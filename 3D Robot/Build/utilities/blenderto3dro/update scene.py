
# The big question is how will we deal with options for imported objects (which the majority of the objects are)
import bpy
import math
import os
import operator
import sys


#get all of the options
optionslist = []
for K in bpy.data.objects['options'].keys():
    if K not in '_RNA_UI':
       optionslist.append(str(K))

       

# deselect all objects
bpy.ops.object.select_all(action='DESELECT')    

# loop through all the objects in the scene
scene = bpy.context.scene

for ob in scene.objects:
# make the current object active and select it
    scene.objects.active = ob
    ob.select = True
    
    # make sure that we only export meshes
	# Only change if it's not a imported type if it is imported then it gets very complex
    if (ob.type == 'MESH') and not(ob.get('objecttype') == 'imported'):
    # change it's position and rotation and scale as per the xyzrxryrz in the options
        x = str(ob.get('X'))
        y = str(ob.get('Y'))
        z = str(ob.get('Z'))
        rx = str(ob.get('RX'))
        ry = str(ob.get('RY'))
        rz = str(ob.get('RZ'))
        sx = str(ob.get('SX'))
        sy = str(ob.get('SY'))
        sz = str(ob.get('SZ'))
        for k in optionslist:
            x = x.replace(k, str(bpy.data.objects['options'].get(k)))
            y = y.replace(k, str(bpy.data.objects['options'].get(k)))
            z = z.replace(k, str(bpy.data.objects['options'].get(k)))
            rx = rx.replace(k, str(bpy.data.objects['options'].get(k)))
            ry = ry.replace(k, str(bpy.data.objects['options'].get(k)))
            rz = rz.replace(k, str(bpy.data.objects['options'].get(k)))
            sx = sx.replace(k, str(bpy.data.objects['options'].get(k)))
            sy = sy.replace(k, str(bpy.data.objects['options'].get(k)))
            sz = sz.replace(k, str(bpy.data.objects['options'].get(k)))
            
        ob.location.x = eval(x)
        ob.location.y = eval(y)
        ob.location.z = eval(z)
        ob.rotation_euler.x = math.radians(eval(rx))
        ob.rotation_euler.y = math.radians(eval(ry))
        ob.rotation_euler.z = math.radians(eval(rz))
        ob.scale.x = eval(sx)
        ob.scale.y = eval(sy)
        ob.scale.z = eval(sz)
        
