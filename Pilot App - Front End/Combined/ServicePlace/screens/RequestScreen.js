import React from 'react';
import {StyleSheet, View, TouchableOpacity, Button,Text, TextInput,TouchableWithoutFeedback, Keyboard} from 'react-native';

const DismissKeyboard = ({children}) => ( <TouchableWithoutFeedback onPress={() => Keyboard.dismiss()}>{children}</TouchableWithoutFeedback>)
// void function()
// {
// if (state = 'red'){
//   // render Emergency Screen
// }
// else if (state = 'yellow'){}
// }

class RequestScreen extends React.Component {
  
  render() {
    return (
    <DismissKeyboard>
      <View style={styles.container}>
        <Text>New Request</Text>
        {/* Create a Function here that displays what type of request was sent from the HomeScreen to draw color button  */}
        <View style={[styles.circle, styles.yellow]}></View> 
        {/* Smaller Request Dot */}
        <TextInput style={styles.textFields} placeholder='Email Address' multiline={true} numberOfLines={4}/>
       
        <Button title="History" onPress={()=> this.props.navigation.navigate("ElderListS") }/>
      </View>
    </DismissKeyboard>
    );}
}
export default RequestScreen;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#DCDCDC',
   },
  welcome: {
      flex: 1,
  },
  circle: {
    width: 40,
    height: 40,
    borderRadius: 40/2,
    backgroundColor: '#F32D0A',
    marginBottom: 15,
    marginTop: 10,
},
green: { backgroundColor:'#0D8E11' },
yellow: { backgroundColor:'#F7EB33'},
textFields:{
    backgroundColor:'rgba(255,255,255,0.7)',
    height: 100,
    textAlign: 'left',
    margin: 15,
    width: '80%',
    
},
});
