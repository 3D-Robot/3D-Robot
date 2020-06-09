import bpy
# here we just do auto work nice to do after options are there but before export fully to 3dro
#change all to imported

allObjects = list(bpy.data.objects)

for element in allObjects:
        # first check for overwrite if it was never modified and still is 1.000 then change it
        if str(element.get("priority")) == "1.000":
                if str(element.get("material")) == "pla":
                    element["priority"] = 100.0
                elif str(element.get("material")) == "plastic":
                    element["priority"] = 100.0
                elif str(element.get("material")) == "aluminum":
                    element["priority"] = 400.0
                elif str(element.get("material")) == "copper":
                    element["priority"] = 500.0
                elif str(element.get("materail")) == "steel":
                    element["priority"] = 600.0
                elif str(element.get("material")) == "hardsteel":
                    element["priority"] = 700.0
                elif str(element.get("material")) == "wood":
                    element["priority"] = 300.0
                elif str(element.get("material")) == "glass":
                    element["priority"] = 700.0
                elif str(element.get("material")) == "nothing":
                    element["priority"] = 10000.0
                elif str(element.get("material")) == "air":
                    element["priority"] = 0.0
                else:
                    element["priority"] = 400.0
    
