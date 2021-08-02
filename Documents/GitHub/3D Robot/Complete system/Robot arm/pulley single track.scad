
outerdia = 50;
cutoutdia = 10;
wireholedia = 2;
addthick = 1;

difference(){
    union(){
        cylinder(r = outerdia/2, h = cutoutdia+addthick*2);
    }
    
    union(){
        translate([0,0,addthick+cutoutdia/2]){rotate_extrude(angle=360){
        translate([outerdia/2,0]){circle(d = cutoutdia);}}}
        
        translate([0,outerdia/2,addthick+cutoutdia/2]){rotate(a = [90,0,0]){cylinder(r = wireholedia/2, h = outerdia);}}
    }
}
