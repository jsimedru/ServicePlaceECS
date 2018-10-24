import React from 'react';
import { createStackNavigator } from 'react-navigation';
import { AppRegistry, StyleSheet, Text, View, TouchableOpacity, Image, Button, ScrollView, Platform, TextInput } from 'react-native';

global.HistoryList = [
    {
        type:"yellow",
        message:"Request walk in Park",
        complete: 'no'
    },
    {
        type:"yellow",
        message:"Veg dinner delivery",
        complete: 'no'
    },
    {
        type:"green",
        message:"1 L milk tomorrow AM",
        complete: 'no'
    },
    {
        type:"yellow",
        message:"Request walk in Park",
        complete: 'yes'
    },
    {
        type:"green",
        message:"1 L milk tomorrow AM",
        complete: 'yes'
    },
    {
        type:"red",
        message:"Fell down – need doctor",
        complete: 'yes'
    },
    {
        type:"green",
        message:"Movie show Saturday",
        complete: 'yes'
    },
    {
        type:"green",
        message:"Wanted a friend to talk to",
        complete: 'yes'
    },
    {
        type:"red",
        message:"I hit my head!",
        complete: 'yes'
    },
    {
        type:"red",
        message:"Discomfort in ears",
        complete: 'yes'
    },
    {
        type:"yellow",
        message:"Need to go shopping for clothes",
        complete: 'yes'
    },
    {
        type:"yellow",
        message:"I would like to go golfing",
        complete: 'yes'
    },
    ];


class InitiateRequestScreen extends React.Component
{
  constructor(props) {
    super(props);
    this.state = { text: 'Enter Here' };
  }
    renderHistory(item)
    {
        circleColor = ''
        circleBorderColor = ''

        if (item['type'] == 'green')
            circleColor = 'green'
        else if (item['type'] == 'yellow')
            circleColor = 'yellow'
        else if (item['type'] == 'red')
            circleColor = 'red'

        if (item['complete'] == 'yes')
            circleBorderColor = 'black'
        else if (item['complete'] == 'no')
            circleBorderColor = 'white'

        return <View style = {[styles.historyCircle,{backgroundColor:circleColor,borderColor:circleBorderColor}]}></View>
    }

  render()
  {

    const { navigation } = this.props;
    const requestType = navigation.getParam('requestType');

    return(
      <View style = {{flex: 1}}>

        <View style={[styles.bannerBackground,,{borderBottomWidth:3}]}>
            <Text style={styles.bannerText}>Gurudakshina Elder Care System</Text>
            <Text style={styles.bannerText}>New Request</Text>
        </View>

        <ScrollView style={{backgroundColor:'rgb(128,0,0)'}}>
        {
            global.HistoryList.map((item, key) =>
            (
                <View key = {key}>
                    <View style={{flex: 1, flexDirection: 'row'}}>
                        {this.renderHistory(item)}
                        <Text style = {styles.historyItemText}>{item['message']}</Text>
                    </View>
                </View>

            ))
        }
        </ScrollView>

        <View style={{borderTopWidth:3,backgroundColor: 'rgb(244,164,96)'}}>
            <View style={{alignItems:'center'}}>
                <View style = {[styles.requestCircle,{backgroundColor:requestType,borderColor:'white'}]}></View>
            </View>
            <View>
                <TextInput
                        style={{borderColor: 'rgb(128,0,0)', borderWidth: 2, backgroundColor: 'white'}}
                        onChangeText={(text) => this.setState({text})}
                        value={this.state.text}
                      />
            </View>
        </View>

        <View style={{backgroundColor: 'rgb(244,164,96)'}}>
            <TouchableOpacity style={styles.confirmButton} onPress={() => this.props.navigation.navigate('Request')}>
                <Text style={styles.backButtonText}>Confirm</Text>
            </TouchableOpacity>
            <TouchableOpacity style={styles.backButton} onPress={() => this.props.navigation.navigate('Request')}>
                <Text style={styles.backButtonText}>Back</Text>
            </TouchableOpacity>
        </View>
      </View>
    )
  }


}

class RequestScreen extends React.Component
{
  render()
  {
    return (
      <View style={{flex: 1, backgroundColor: 'rgb(244,164,96)'}}>
        <View style={styles.bannerBackground}>
            <Text style={styles.bannerText}>Gurudakshina Elder Care System</Text>
        </View>

        <View style={styles.helpButtonBackground}>
            <TouchableOpacity style={[styles.helpButton,{backgroundColor: 'green'}]} onPress={() => this.props.navigation.navigate('InitiateRequest', {requestType:'green'})}></TouchableOpacity>
            <TouchableOpacity style={[styles.helpButton,{backgroundColor: 'yellow'}]} onPress={() => this.props.navigation.navigate('InitiateRequest', {requestType:'yellow'})}></TouchableOpacity>
            <TouchableOpacity style={[styles.helpButton,{backgroundColor: 'red'}]} onPress={() => this.props.navigation.navigate('InitiateRequest', {requestType:'red'})}></TouchableOpacity>
        </View>

        <View style={styles.historyButtonBackground}>
            <TouchableOpacity style={styles.historyButton} onPress={() => this.props.navigation.navigate('History')}>
                <Text style={styles.historyButtonText}>History</Text>
            </TouchableOpacity>
        </View>

        <View style={{alignItems:'center'}}>
            <Image source={require('./Images/ServicePlaceLogo.png')}/>
        </View>
      </View>
    );
  }
}

class HistoryScreen extends React.Component
{
    renderHistory(item)
    {
        circleColor = ''
        circleBorderColor = ''

        if (item['type'] == 'green')
            circleColor = 'green'
        else if (item['type'] == 'yellow')
            circleColor = 'yellow'
        else if (item['type'] == 'red')
            circleColor = 'red'

        if (item['complete'] == 'yes')
            circleBorderColor = 'black'
        else if (item['complete'] == 'no')
            circleBorderColor = 'white'

        return <View style = {[styles.historyCircle,{backgroundColor:circleColor,borderColor:circleBorderColor}]}></View>
    }

  render()
  {
    return(
      <View style = {{flex: 1}}>
        <View style={[styles.bannerBackground,,{borderBottomWidth:3}]}>
            <Text style={styles.bannerText}>Gurudakshina Elder Care System</Text>
            <Text style={styles.bannerText}>Recent History</Text>
        </View>

        <ScrollView style={{backgroundColor:'rgb(128,0,0)'}}>
        {
            global.HistoryList.map((item, key) =>
            (
                <View key = {key}>
                    <View style={{flex: 1, flexDirection: 'row'}}>
                        {this.renderHistory(item)}
                        <Text style = {styles.historyItemText}>{item['message']}</Text>
                    </View>
                </View>

            ))
        }
        </ScrollView>

        <View style={{borderTopWidth:3, backgroundColor: 'rgb(244,164,96)'}}>
            <TouchableOpacity style={styles.backButton} onPress={() => this.props.navigation.navigate('Request')}>
                <Text style={styles.backButtonText}>Back</Text>
            </TouchableOpacity>
        </View>

        <View style={{alignItems:'center', backgroundColor: 'rgb(244,164,96)'}}>
            <Image source={require('./Images/ServicePlaceLogo.png')}/>
        </View>
      </View>
    )
  }

}

export default class App extends React.Component
{
  render()
  {
    return <RootStack />;
  }
}

const RootStack = createStackNavigator(
  {
    Request:
    {
        screen: RequestScreen,
        navigationOptions: () => ({
            header: null})
    },
    History:
    {
        screen: HistoryScreen,
        navigationOptions: () => ({
            header: null})
    },
    InitiateRequest:
    {
        screen: InitiateRequestScreen,
        navigationOptions: () => ({
            header: null})

    }
  },
  {
    initialRouteName: 'Request',
  }
);

const styles = StyleSheet.create(
{
  bannerBackground:
  {
    alignItems: 'center',
    backgroundColor: 'rgb(244,164,96)'
  },
  bannerText:
  {
    fontSize: 20,
    color: 'rgb(128,0,0)',
    fontWeight: 'bold'
  },
  helpButtonBackground:
  {
    alignItems: 'center',
  },
  helpButton:
  {
    borderRadius:100,
    borderWidth:3,
    borderColor:'black',
    alignItems: 'center',
    width: 130,
    height: 130,
    margin: 10
  },
  historyButtonBackground:
  {
    alignItems: 'center'
  },
  historyButton:
  {
    backgroundColor: 'rgb(128,0,0)',
    borderColor:'black',
    borderWidth: 3,
    alignItems: 'center',
    justifyContent:'center',
    width: 100,
    height: 50
  },
  historyButtonText:
  {
   fontSize: 25,
   color: 'white',
   alignItems: 'center'
  },
  backButton:
  {
    backgroundColor: 'rgb(128,0,0)',
    borderColor:'black',
    borderWidth: 3,
    alignItems: 'center',
    justifyContent:'center',
    width: 100,
    height: 50,
    margin: 5
  },
  backButtonText:
  {
    fontSize: 25,
    color: 'white',
    alignItems: 'center'
  },
  historyItemText:
  {
    fontSize: 20,
    color:'black',
    padding: 5,
    backgroundColor:'white',
    flex: 1,
    margin: 3,
    borderColor: 'black',
    borderWidth: 3
  },
  historyCircle:
  {
    borderRadius:100,
    borderWidth:3,
    height: 35,
    width: 35,
    marginTop: 7,
    marginLeft: 3
  },
  requestCircle:
  {
    borderRadius:100,
    borderWidth:3,
    height: 25,
    width: 25,
    marginTop: 7,
    marginBottom: 7
  },
  confirmButton:
  {
    backgroundColor: 'green',
    borderColor:'black',
    borderWidth: 3,
    alignItems: 'center',
    justifyContent:'center',
    width: 100,
    height: 50,
    margin: 5
  }
});
