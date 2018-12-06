import React from 'react';
import {StyleSheet, View, TouchableOpacity, Button, BackHandler, Text} from 'react-native';

const preventBack = BackHandler.addEventListener('hardwareBackPress',function()
{
  
})

class EmployeeHomeScreen extends React.Component 
{
  render() 
  {
    const { navigation } = this.props;
    const Account = navigation.getParam('Account');

    return (
      <View style={styles.container}>
        <Text style={styles.headerText}>Welcome {Account.FirstName} </Text>
        <Text>User Type: Employee</Text>

        <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("ElderListS")}>
          <Text style={styles.buttonText}>Elders</Text>
        </TouchableOpacity>

        <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("RequestListS")}>
          <Text style={styles.buttonText}>Requests</Text>
        </TouchableOpacity> 

        <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("AccountSettingS")}>
          <Text style={styles.buttonText}>Account Settings</Text>
        </TouchableOpacity>
      </View>
    );
  }
}

export default EmployeeHomeScreen;

const styles = StyleSheet.create(
{
  touchBtn:
  {
    backgroundColor: '#DDDDDD',
    padding: 10,
    borderRadius: 10,
    margin: 15,
    alignItems:'center',
    width: 250
  },
  buttonText:
  {
    fontSize: 25
  },
  headerText:
  {
    fontSize: 35
  },
  container: 
  { 
    flex: 1, 
    backgroundColor: '#2980b9',
    alignItems: 'center'
  },
  welcome: 
  {
      flex: 1,
  },
  circle: 
  {
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
