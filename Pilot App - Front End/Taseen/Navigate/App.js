import React from 'react';
import {createStackNavigator} from 'react-navigation';
// Imports Each Screen
import LoginScreen from './screens/LoginScreen'
import ElderHomeScreen from './screens/ElderHomeScreen'
import ElderViewScreen from './screens/ElderViewScreens'
import RegistrationScreen from './screens/RegistrationScreen'
import ForgotPasswordScreen from './screens/ForgottenPassword'
import MultiTypeScreen from './screens/MultiTypeScreen'
export default class App extends React.Component {
  render(){ return( <AppNavigator/> ); }
}

const AppNavigator = createStackNavigator({
  Login: LoginScreen,
  ElderHomeS: ElderHomeScreen,
  ElderListS: ElderViewScreen, 
  Registration: RegistrationScreen,
  ForgotPass: ForgotPasswordScreen,
  MTScreen: MultiTypeScreen
  }, // Sets Navigation Header to be hidden.
  { navigationOptions: { header: null}} 
)

