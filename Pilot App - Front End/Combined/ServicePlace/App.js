import React from 'react';
import {createStackNavigator} from 'react-navigation';

// Imports Each Screen
import LoginScreen from './screens/Login/LoginScreen'
import RegistrationScreen from './screens/Login/RegistrationScreen'
import ForgotPasswordScreen from './screens/Login/ForgottenPassword'
import MultiTypeScreen from './screens/Login/MultiTypeScreen'

import AdminHomeScreen from './screens/Administrator/AdminHomeScreen'

import ManagerHomeScreen from './screens/Manager/ManagerHomeScreen'

import EmployeeHomeScreen from './screens/Employee/EmployeeHomeScreen'
import EmployeeListScreen from './screens/Employee/EmployeeListScreen'
import EmployeeDetailsScreen from './screens/Employee/EmployeeDetailsScreen'

import ElderListScreen from './screens/Elder/ElderListScreen'
import ElderDetailsScreen from './screens/Elder/ElderDetailsScreen'
import ElderHomeScreen from './screens/Elder/ElderHomeScreen'

import RequestScreen from './screens/RequestScreen'


export default class App extends React.Component {
  render(){ return( <AppNavigator/> ); }
}

const AppNavigator = createStackNavigator(
  { 
    Login: LoginScreen,
    Registration: RegistrationScreen,
    ForgotPass: ForgotPasswordScreen,
    MTScreen: MultiTypeScreen,
    
    AdminHomeS: AdminHomeScreen,
    
    ManagerHomeS: ManagerHomeScreen,
    
    EmployeeHomeS: EmployeeHomeScreen,
    EmployeeListS: EmployeeListScreen,
    EmployeeDetailS: EmployeeDetailsScreen,

    ElderHomeS: ElderHomeScreen,
    ElderListS: ElderListScreen,
    ElderDetailS: ElderDetailsScreen,

    Requests: RequestScreen,

    
  }, 
  { // Sets Navigation Header to be hidden.
    navigationOptions: { header: null}
  },
  { //Sets the default screen to...
    initialRouteName: 'Login',
  }
)

