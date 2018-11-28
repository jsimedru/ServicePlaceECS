import React from 'react'
import {Alert, StyleSheet, Text, TextInput, View, TouchableOpacity} from 'react-native'


class ForgottenPassword extends React.Component{
    constructor(){
        super();
        this.state = {email: ''}
    }
    
    authenticate = ()=>{
        if(this.state.email == 'admin@gmail.com'){ Alert.alert('Sent Request..') }else{ Alert.alert('Incorrect Password or Email')} 
      }
    render(){
        return(
        <View style={styles.container}>
            <Text style={{fontSize: 24}}> Forgot your Password?</Text>
            <Text style={{textAlign:'center'}}> Please enter in the email address of the ServicePlace account you are trying to recover:</Text>
            <View style={styles.inputFields}> 
                <TextInput style={styles.textFields} placeholder='Email Address' keyboardType='email-address'
                onChangeText={(typedTxt)=>{ this.setState({email: typedTxt});}}
                />
                <TouchableOpacity style={styles.touchBtn} onPress={this.authenticate}><Text>Reset Password</Text></TouchableOpacity> 
            </View>
        </View>
        );
    }
}
export default ForgottenPassword;

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