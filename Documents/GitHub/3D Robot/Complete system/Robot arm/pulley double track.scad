
outerdia = 25;
cutoutdia = 5;
wireholedia = 2;
addthick = 1;
shaftdia = 8;

difference(){
    union(){
        cylinder(r = outerdia/2, h = (cutoutdia+addthick*1.5)*2);
    }
    
    union(){
        translate([0,0,-.5]){cylinder(r = shaftdia/2, h = (cutoutdia+addthick*1.5)*2 + 1);}
        
        translate([0,0,addthick+cutoutdia/2]){rotate_extrude(angle=360){
        translate([outerdia/2,0]){circle(d = cutoutdia);}}}
    
        translate([0,0,addthick+3*cutoutdia/2+addthick]){rotate_extrude(angle=360){
        translate([outerdia/2,0]){circle(d = cutoutdia);}}}
    
        translate([shaftdia,outerdia/2,addthick+cutoutdia/2]){rotate(a = [90,0,0]){cylinder(r = wireholedia/2, h = outerdia);}}
        
        translate([shaftdia,outerdia/2,addthick+3*cutoutdia/2+addthick]){rotate(a = [90,0,0]){cylinder(r = wireholedia/2, h = outerdia);}}
    }
}
