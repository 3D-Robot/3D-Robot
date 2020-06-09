include<threads.scad>;
wallthickness = 2;
threaddia = 12.7;
threadlegnth = 10;
threadpitch = 25.4/13;

difference(){
    translate([-(threaddia+wallthickness*2)/2,-(threaddia+wallthickness*2)/2,.005]){cube([threaddia+wallthickness*2,threaddia+wallthickness*2,threadlegnth-.01]);}
    translate(){   metric_thread (diameter=threaddia, pitch=threadpitch, length=threadlegnth, internal=true, n_starts=1);}
}