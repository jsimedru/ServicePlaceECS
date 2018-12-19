import React from 'react';
import {StyleSheet, View, TouchableOpacity, Button, BackHandler, Dimensions,Text} from 'react-native';

const preventBack = BackHandler.addEventListener('hardwareBackPress',function(){})

function tabletView(){
  if(Dimensions.get('window').width >= 415){
    return( 
    <View>
      <TouchableOpacity style={styles.touchBtn}><Text>Extra Button Only on Tablet View</Text></TouchableOpacity>
      <TouchableOpacity style={styles.touchBtn}><Text>Extra Tablet View</Text></TouchableOpacity>
    </View> 
    )}
}

class ElderHomeScreen extends React.Component {
    
  render() {
    return (
      <View style={styles.container}>
        <TouchableOpacity style={[styles.circle, styles.green]}onPress={()=> this.props.navigation.navigate("ElderListS") }></TouchableOpacity>
        <TouchableOpacity style={[styles.circle, styles.yellow]}onPress={()=> this.props.navigation.navigate("Requests")}></TouchableOpacity>
        <TouchableOpacity style={styles.circle}></TouchableOpacity>
        {tabletView()}
        <Button title="History" onPress={()=> this.props.navigation.navigate("ElderListS") }/>
      </View>
    );
  }
}

export default ElderHomeScreen;

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
    width: 180,
    height: 180,
    borderRadius: 180/2,
    backgroundColor: '#F32D0A',
    marginBottom: 15,
    marginTop: 10,
    flex:1
},
touchBtn:{
  backgroundColor: '#636e72',
  padding: 10,
  borderRadius: 10,
  margin: 10,
  alignItems:'center',
},
green: { backgroundColor:'#0D8E11' },
yellow: { backgroundColor:'#F7EB33'}
});
