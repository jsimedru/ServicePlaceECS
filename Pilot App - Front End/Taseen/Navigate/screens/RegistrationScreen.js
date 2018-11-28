import React from 'react';
import { Text, View, StyleSheet } from 'react-native';

 class Registration extends React.Component {
     
  render() {
    return (
      <View style={styles.container}>
        <Text style={{ textAlign:'center'}}>To register, please email:</Text>
        
      </View> 
    );
  }
}
 
export default Registration;

const styles = StyleSheet.create({ container: { flex: 1, backgroundColor: '#f39c12', }, });