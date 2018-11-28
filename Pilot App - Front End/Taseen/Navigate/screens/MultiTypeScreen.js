import React from 'react'
import {Alert, StyleSheet, Text, View, TouchableOpacity} from 'react-native'


class MultiTypeScreen extends React.Component{
    constructor(){
        super();
        this.state = {email: ''}
       }
       authenticate = ()=>{
        if(this.state.email == 'admin@gmail.com'){
           Alert.alert('Logging In..')
        }else{ 
          Alert.alert('Incorrect Password or Email')
        } 
      }
    render(){
        return(
        <View style={styles.container}>
                <TouchableOpacity style={styles.touchBtn} onPress={this.authenticate}><Text>Chief Admin - Token 1</Text></TouchableOpacity>              
                <TouchableOpacity style={styles.touchBtn} onPress={this.authenticate}><Text>Family Membder - Type 2</Text></TouchableOpacity> 

        </View>
        );
    }
}
export default MultiTypeScreen;

const styles = StyleSheet.create({
    container: { flex: 1, flexDirection:'column', backgroundColor: '#78909C', alignItems: 'center', paddingTop:60,   },
    inputFields:{ width: '95%', alignItems:'center' },
    textFields:{
        backgroundColor:'rgba(255,255,255,0.7)',
        height: 40,
        textAlign: 'center',
        margin: 15,
        borderRadius: 160,
        width:'80%'
    },
    touchBtn:{
        backgroundColor: '#DDDDDD',
        padding: 10,
        borderRadius: 10,
        margin: 10,
        width:'40%',
        alignItems:'center',
      },
    

});