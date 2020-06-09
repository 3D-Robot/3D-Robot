import bpy
import math
import os

#executable code begins---------------------------
# get the path where the blend file is located
basedir = bpy.path.abspath('//')
# deselect all objects
bpy.ops.object.select_all(action='DESELECT')    

# loop through all the objects in the scene
scene = bpy.context.scene
full = 'state: overview' + '\n' + '\n' + '{' + '\n' + 'options:' + '\n'
#write in all custom properties which are the options
for K in bpy.data.objects['options'].keys():
    if K not in '_RNA_UI':
        full = full + str(K) + ' = ' + str(bpy.data.objects['options'].get(str(K))) + '\n'
full = full + '\n' + '}' + '\n' + '\n'

scalex = 0.0
scaley = 0.0
scalez = 0.0
for ob in scene.objects:
# make the current object active and select it
    scene.objects.active = ob
    ob.select = True
    
    # make sure that we only export meshes
    if ob.type == 'MESH':
    # create the complete .3dro file to be saved

        if str(ob.get("objecttype")) == "cube":
            scalex = str(ob.get('SX')) + '*2'
            scaley = str(ob.get('SY')) + '*2'
            scalez = str(ob.get('SZ')) + '*2'
        elif str(ob.get("objecttype")) == "cylinder":
            scalex = ob.get('SX')
            scaley = ob.get('SY')
            scalez = ob.get('SZ')
        else:
            scalex = ob.get('SX')
            scaley = ob.get('SY')
            scalez = ob.get('SZ')

        if (type(ob.get('RX')) == float):
            rotatex = math.degrees(float(ob.get('RX')))
        else:
            rotatex = ob.get('RX')
        if (type(ob.get('RY')) == float):
            rotatey = math.degrees(float(ob.get('RY')))
        else:
            rotatey = ob.get('RY')
        if (type(ob.get('RZ')) == float):
            rotatez = math.degrees(float(ob.get('RZ')))
        else:
            rotatez = ob.get('RZ')
        
        full = (full + '\n' + "object" + '\n' +
        "material " + str(ob.get("material")) + '\n' +
        "position(" + str(ob.get('X')) + " ," + str(ob.get('Y')) + "," + str(ob.get('Z')) + ")" + '\n' +
        "rotation(" + str(rotatex) + "," + str(rotatey) + "," + str(rotatez) + ")" + '\n' +
        str(ob.get("objecttype")) +"(" + str(scalex) + "," + str(scaley) + "," + str(scalez) + ")" + '\n' + 
        "Priority = " + str(ob.get("priority")) + '\n' + 
        "name = " + str(ob.name) + '\n')

        if str(ob.get("objecttype")) == "imported":
            #export the stl to a file called import for the 3D Robot software to import that stl
            if not os.path.exists(basedir + '/import/'):
                os.makedirs(basedir + '/import/')
            #center the stl export it then uncenter it again
            posx = ob.location.x
            posy = ob.location.y
            posz = ob.location.z
            rotx = ob.rotation_euler.x
            roty = ob.rotation_euler.y
            rotz = ob.rotation_euler.z
            ob.location.x = 0
            ob.location.y = 0
            ob.location.z = 0
            ob.rotation_euler.x = 0
            ob.rotation_euler.y = 0
            ob.rotation_euler.z = 0
            bpy.ops.export_mesh.stl(filepath= basedir + '/import/' + str(ob.name) + '.stl', use_selection = True, ascii = True)
            ob.location.x = posx
            ob.location.y = posy
            ob.location.z = posz
            ob.rotation_euler.x = rotx
            ob.rotation_euler.y = roty
            ob.rotation_euler.z = rotz
            
                    
# deselect the object and move on to another if any more are left
    ob.select = False
        
print(full)
