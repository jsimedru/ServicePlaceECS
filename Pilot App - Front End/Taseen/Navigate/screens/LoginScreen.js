import React from 'react';
import {StyleSheet, Alert, Text, View,TouchableOpacity, TextInput, TouchableWithoutFeedback, Keyboard} from 'react-native';
// Hides The Keyboard From anywhere on the screen
const DismissKeyboard = ({children}) => (
  <TouchableWithoutFeedback onPress={() => Keyboard.dismiss()}>{children}</TouchableWithoutFeedback>
)
CareHomeList = [
  {
    Name: "Taseen",
    Password: "admin",
    MultiTokens: "yes",
    token1: "Employee",
    token2: "FamilyMember"
  },  {
    Name: "Elder",
    Password: "1",
    MultiTokens: "no",
    token1: "Elderly"
  },
  {
    Name: "123",
    Password: "1",
    MultiTokens: "no",
  

  },  {
    Name: "Employee",
    Password: "1",
    MultiTokens: "yes",
    token1: "Employee",
    token2: "FamilyMember"
  }

]
 class LoginScreen extends React.Component {
   constructor(){
    super();
    this.state = {name: '', password: ''}
   }
   // Find a way to fetch values from server. Fetch from server. Fetch token If(elder) -> elderScreen
   // if(care home manager) -> carehomeManager ..... etc...
  authenticate = ()=>{
     if(this.state.name == 'admin' && this.state.password == '123' && CareHomeList[2].MultiTokens == 'no'){
        // Alert.alert('Logging In..')
        this.props.navigation.navigate("ElderHomeS")
     }
     else if(this.state.name == 'admins' && this.state.password == '123' && CareHomeList[3].MultiTokens == 'yes'){
        this.props.navigation.navigate("MTScreen")
     }
     else{ 
       Alert.alert('Incorrect Password or Email')
     } 
   }
  render() {
    return (
    <DismissKeyboard>     
      <View style={styles.container}>
        <View style={styles.top}>
          <Text style={styles.welcome}>Welcome to ServicePlace Login!</Text>
          <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("ElderHomeS")}>
            <Text>Temporary Elder Home</Text>
          </TouchableOpacity> 
        </View>
        <View style={styles.bottom}>
          
          <View style={styles.inputFields}> 
            <TextInput style={styles.textFields} placeholder='Email Address' keyboardType='email-address'
            onChangeText={(typedTxt)=>{ this.setState({name: typedTxt});}} 
            // value= {this.state.name}
           />
            <TextInput style={styles.textFields} placeholder='Password' secureTextEntry
            onChangeText={(typedTxt)=>{ this.setState({password: typedTxt});}} 
            // value={this.state.password}
            />
          </View>
          <TouchableOpacity style={[styles.touchBtn,{width:'50%'}]} onPress={this.authenticate}>
          {/* ()=> this.props.navigation.navigate("#") */}
          <Text>Login</Text></TouchableOpacity> 

          <View style={styles.forgotRegister}>
            <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("Registration") }>
              <Text>Register</Text></TouchableOpacity> 
            <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("ForgotPass") }>
            <Text>Forgot Password?</Text></TouchableOpacity>  
          </View> 

          </View>    
      </View>
    </DismissKeyboard>
    );}
}

export default LoginScreen;

const styles = StyleSheet.create({
  touchBtn:{
    backgroundColor: '#DDDDDD',
    padding: 10,
    borderRadius: 10,
    margin: 10,
    alignItems:'center',
  },
  container: { flex: 1, backgroundColor: '#2980b9'},
  welcome: { fontSize: 20, margin: 10, },

  top:{
    // backgroundColor: '#E5E5FF',
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  forgotRegister:{
  // backgroundColor: 'red',
    flexDirection: 'row',
    alignContent: 'center',
    justifyContent: 'flex-end',
    paddingTop: 35,

   },
  bottom:{ flex: 1, alignItems: 'center', // backgroundColor:'#f39c12',
  },
  inputFields:{ width: '85%'},
  
  textFields:{
    backgroundColor:'rgba(255,255,255,0.7)',
    height: 40,
    textAlign: 'center',
    margin: 15,
    borderRadius: 160,
},
});
