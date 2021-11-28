Shader "Unlit/Portal"
{
   Subshader{
       
       ZWrite off
       ColorMask 0
       
       Stencil{
           Ref 1
           Pass replace
           }
       
       Pass{
           
           }
   }
}
