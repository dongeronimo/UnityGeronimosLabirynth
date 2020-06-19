package com.dongeronimo.multiplayer.teste.SharedWorld.model;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

public class Vector3 {
    public Float x;
    public Float y;
    public Float z;

    // public Vector3(){
    //     x=0.0f;
    //     y=0.0f;
    //     z=0.0f;
    // }

    // public Vector3(Float x, Float y, Float z){
    //     this.x = x;
    //     this.y = y;
    //     this.z = z;
    // }
    // @Override
    // public boolean equals(Object o){
    //     if(o==null || o instanceof Vector3 == false){
    //         return false;
    //     }else{
    //         Float E = 10e-4f;
    //         Vector3 other = (Vector3)o;
    //         return Math.abs(other.x-this.x)<E && Math.abs(other.y-this.y)<E && Math.abs(other.z-this.z)<E;
    //     }
    // }
    // @Override
    // public int hashCode(){
    //     return x.hashCode() + y.hashCode() *11 + z.hashCode() * 23;
    // }
    // @Override
    // public String toString(){
    //     try {
	// 		return new ObjectMapper().writeValueAsString(this);
	// 	} catch (JsonProcessingException e) {
	// 		return "unable to serialize to json";
	// 	}
    // }

	// public Float getY() {
	// 	return y;
	// }
	// public Float getZ() {
	// 	return z;
	// }
	// public void setZ(Float z) {
	// 	this.z = z;
	// }
	// public Float getX() {
	// 	return x;
	// }
	// public void setX(Float x) {
	// 	this.x = x;
	// }
	// public void setY(Float y) {
	// 	this.y = y;
	// }

    
    
}