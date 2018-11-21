import React from 'react';
import {StyleSheet, View, TouchableOpacity, Button, BackHandler} from 'react-native';

const preventBack = BackHandler.addEventListener('hardwareBackPress',function(){
  
})

class ElderHomeScreen extends React.Component {
    
  render() {
    return (
      <View style={styles.container}>
        <TouchableOpacity style={[styles.circle, styles.green]} 
        onPress={()=> this.props.navigation.navigate("ElderListS") }>    
        </TouchableOpacity>
        <TouchableOpacity  style={[styles.circle, styles.yellow]}></TouchableOpacity>
        <TouchableOpacity  style={styles.circle}></TouchableOpacity>
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
green: { backgroundColor:'#0D8E11' },
yellow: { backgroundColor:'#F7EB33'}
});
