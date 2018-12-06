import React from 'react';
import {StyleSheet, Alert, Text, View,TouchableOpacity, TextInput, TouchableWithoutFeedback, Keyboard} from 'react-native';
// Hides The Keyboard From anywhere on the screen
const DismissKeyboard = ({children}) => (
  <TouchableWithoutFeedback onPress={() => Keyboard.dismiss()}>{children}</TouchableWithoutFeedback>
)

UserList = [
  {
    Email: "admin",
    Password: "password",
    UserType: "Administrator",
    FirstName: "James",
    LastName: "Podobea"
  },
  {
    Email: "twotypes",
    Password: "password",
    UserType: "Administrator,Manager",
    FirstName: "Cristina",
    LastName: "Serban"
  },
  {
    Email: "manager",
    Password: "password",
    UserType: "Manager",
    FirstName: "Jasen",
    LastName: "Simedru"
  },
  {
    Email: "volunteer",
    Password: "password",
    UserType: "Volunteer",
    FirstName: "Joe",
    LastName: "Smith"
  },
  {
    Email: "elder",
    Password: "password",
    UserType: "Elder",
    FirstName: "Margaret",
    LastName: "Bittner"
  },
  {
    Email: "family",
    Password: "password",
    UserType: "Family",
    FirstName: "Jack",
    LastName: "Scott"
  }
]


 class LoginScreen extends React.Component {
   constructor(){
    super();
    this.state = {name: '', password: ''}
   }

  authenticate = ()=>
  {
    var EmailExists = new Boolean(false);
    var PassWordMatches = new Boolean(false);
    var UserNumberInList = null
    //Loops through the User's List
    for (var i = 0; i < UserList.length; i++) 
    {
      //Checks to see if the entered Email address exists in the UserList
      if (UserList[i].Email.toLowerCase() == this.state.name.toLowerCase())
      {
        EmailExists = true;
        UserNumberInList = i
      }
    }
    //If the Email address exists, then check that the password matches
    if (EmailExists == true)
    {

      //If the password entered does matches what is in the UserList
      if (UserList[UserNumberInList].Password == this.state.password)
      {
        //Checks to see how many UserTypes the account has
        var AccountTypes = UserList[UserNumberInList].UserType.split(',');
        
        //If there are more than 1 account types
        if (AccountTypes.length > 1)
        {
          this.props.navigation.navigate("MTScreen",{Account : UserList[UserNumberInList]});
        }
        //If there is only 1 account type
        else if (AccountTypes.length = 1)
        {
          //Navigate to the different Home screens based on what the Account Type is
          //Chief Administrator
          if (AccountTypes[0] == "Administrator")
          {
            this.props.navigation.navigate("AdminHomeS",{Account : UserList[UserNumberInList]});
          }
          //Regional Manager
          else if (AccountTypes[0] == "Manager")
          {
            this.props.navigation.navigate("ManagerHomeS",{Account : UserList[UserNumberInList]});
          }
          //CareGiver / Volunteer
          else if (AccountTypes[0] == "Volunteer")
          {
            this.props.navigation.navigate("EmployeeHomeS",{Account : UserList[UserNumberInList]});
          }
          //Elder
          else if (AccountTypes[0] == "Elder")
          {
              this.props.navigation.navigate("ElderHomeS",{Account : UserList[UserNumberInList]});
          }
          //Family Member
          else if(AccountTypes[0] == "Family")
          {
              alert("Render Family Page");
          }
        }
      }
      //If the password entered does not match what is in the UserList
      else
      {
        alert("Invalid Email or Password!");
      }
    }
    //If the Email address does not exist in the UserList
    else
    {
      alert("Invalid Email or Password!");
    }
  }

  render() {
    return (
    <DismissKeyboard>     
      <View style={styles.container}>
        <View style={styles.top}>
          <Text style={styles.welcome}>Welcome to ServicePlace Login!</Text>
          {/*
          <TouchableOpacity style={styles.touchBtn} onPress={()=> this.props.navigation.navigate("ElderHomeS")}>
            <Text>Temporary Elder Home</Text>
          </TouchableOpacity> 
          */}
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
