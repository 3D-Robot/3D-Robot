pulleydia = 50;
overhang = 10;
pulleythick = 10;
overhangthick = 1;
wiredia = 2;

difference(){
    union(){
        translate([0,0,-(pulleythick)/2]){cylinder(r = pulleydia/2, h = pulleythick);}
        translate([0,0,(pulleythick)/2]){cylinder(r = (pulleydia+overhang*2)/2, h = overhangthick);}
        translate([0,0,-(pulleythick)/2-overhangthick]){cylinder(r = (pulleydia+overhang*2)/2, h = overhangthick);}
    }
    
    union(){
                translate([0,outerdia/2,0]){rotate(a = [90,0,0]){cylinder(r = wiredia/2, h = pulleydia);}}
    }
}