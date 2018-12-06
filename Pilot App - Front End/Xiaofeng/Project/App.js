import React, { Component } from 'react';
import { Alert, AppRegistry, Button, Platform, StyleSheet, Text, TouchableHighlight, TouchableOpacity, TouchableNativeFeedback, TouchableWithoutFeedback, View } from 'react-native';
import { createStackNavigator,createAppContainer, StackActions, NavigationActions  } from 'react-navigation';

function renderEldersButton()
{
return (
      <ListItem

        <Button/>
        //onPress={this._onPressButton}
        //onPress={() => this.props.navigation.navigate('List')
        title="Elder"
        />
      />
                );
}

function renderRequestsButton(){

return (
      <ListItem

       <Button onPress={this._onPressButton}
        //onPress={() => this.props.navigation.navigate('List')
         title="Requests"

        />
                );
}

function renderEmployeesButton(){
return (
      <ListItem

       <Button onPress={this._onPressButton}
        //onPress={() => this.props.navigation.navigate('List')
         title="Employees"

        />
                );
               }

function renderCareHomesButton(){
return (
      <ListItem

       <Button onPress={this._onPressButton}
        //onPress={() => this.props.navigation.navigate('List')
         title="Care Homes"

        />
                );
}

function renderAccountSettingsButton(button)
{
  return(
    <View>
        title="Account Settings"
        <Button onPress={this._onPressButton}
        //onPress={() => this.props.navigation.navigate('List')

        />
        </View>
  )
}

/*
export default class HomeScreen extends Component {


  _onPressButton() {
    Alert.alert('Button work!')
  }
 render() {
      return (

      // <View>
               // <Text>Welcome!</Text>
             // </View>
        <View style={styles.container}>
          <View style={styles.buttonContainer}>
            <Button
              onPress={this._onPressButton}
              title="Elder"
            />
          </View>
          <View style={styles.buttonContainer}>
            <Button
              onPress={this._onPressButton}
              title="Requests"
            />
          </View>
          <View style={styles.buttonContainer}>
            <Button
              onPress={this._onPressButton}
              title="Employees"
            />
            </View>
            <View style={styles.buttonContainer}>
            <Button
              onPress={this._onPressButton}
              title="Care Homes"
              />
          </View>
          <View style={styles.buttonContainer}>
           <Button
             onPress={this._onPressButton}
              title="Account Settings"
               />
            </View>
        </View>
      );
    }
  }

const styles = StyleSheet.create({
  container: {
   flex: 1,
   justifyContent: 'center',
  },
  buttonContainer: {
    margin: 20
  },
  alternativeLayoutButtonContainer: {
    margin: 20,
    flexDirection: 'row',
    justifyContent: 'space-between'
  }
})
*/


class ChooseScreen extends Component {
  render() {
    return (
    <View style={{ flex: 1, justifyContent: 'center', margin: 20}}>
      <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center'}}>
        <Text>Choose Screen</Text>
        </View>

        <View style={{ flex: 1, justifyContent: 'center', margin: 20}}>
        <Button
          title="User1"
          onPress={() => this.props.navigation.navigate('Home')}
        />
</View>

<View style={{ flex: 1, justifyContent: 'center', margin: 20}}>
 <Button
         title="User2"
          onPress={() => this.props.navigation.navigate('Home')}
               />
      </View>

 <View style={{ flex: 1, justifyContent: 'center', margin: 20}}>
        <Button
          title="User3"
          onPress={() => this.props.navigation.navigate('Home')}
        />
</View>

     </View>
    );
  }
}

function PickWhatToRender(ButtonSelected)
{
    UserType = ButtonSelected
}

function RenderHomeScreen()
{
     if (UserType == "User1")
        {
          return(
          <View>
          <Text>Welcome, </Text>
           renderEldersButton()
           renderRequestsButton()
           renderEmployeesButton()
           renderCareHomesButton()
           </View>
          )
        }
        else if (UserType == "User2")
        {
          return(
           <View>
            <Text>Welcome, </Text>
            renderEldersButton()
            renderRequestsButton()
            renderEmployeesButton()
            </View>
          )
        }
        else if (UserType == "User3")
        {
          return(
           <View>
           <Text>Welcome, </Text>
            renderEldersButton()
            renderRequestsButton()
            </View>
          )
        }
    return(
        renderAccountSettingsButton()
    )

}



class HomeScreen extends Component {
  render() {
    return (
     RenderHomeScreen
    );
  }
}


const RootStack = createStackNavigator(
  {
    Start:ChooseScreen,
    Home:HomeScreen,
    List:ListsScreen,

  }

);


const AppContainer = createAppContainer(RootStack);

export default class App extends React.Component {
  render() {
    return <ChooseScreen />;
  }
}

/*class ListsScreen extends Component {
    render() {
      return (
       RenderListScreen
      );
    }
  }
  */


  /*
  function ListsScreen()
  {
       if (UserType == "Elder")
          {
            return(
            <View>

             </View>
            )
          }

          else if (UserType == "Requests")
          {
            return(
             <View>

              </View>
            )
          }

          else if (UserType == "Employees")
          {
            return(
             <View>

              </View>
            )
          }

          else if (UserType == "Care Homes")
            {
             return(
              <View>

               </View>
              )
           }

           else if (UserType == "Account Settings")
            {
             return(
              <View>

               </View>
             )
            }

  }
  */