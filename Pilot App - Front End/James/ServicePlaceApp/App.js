import React, { Component } from "react";
import { View, Text, FlatList, Alert, TouchableOpacity, StyleSheet, Button } from "react-native";
import { List, ListItem } from "react-native-elements";
import { createStackNavigator } from 'react-navigation';

{/*'''''''''Here are the sample data structures''''''''''*/}
ElderList =[
  {
    FirstName:"Elder1",
    LastName: "Smith",
    Age: 72,
    Birthday: "10/27/1946",
    CareHome: "Olive Grove",
    avatar_url: "https://s3.amazonaws.com/uifaces/faces/twitter/ladylexy/128.jpg",
    ElderID: 1
  },
  {
    FirstName:"Elder2",
    LastName: "Star",
    Age: 68,
    Birthday: "10/27/1950",
    CareHome: "Golden Rose",
    avatar_url: "https://s3.amazonaws.com/uifaces/faces/twitter/adhamdannaway/128.jpg",
    ElderID: 2
  },
  {
    FirstName:"Elder3",
    LastName: "Parker",
    Age: 27,
    Birthday: "10/27/1991",
    avatar_url: "https://randomuser.me/api/portraits/women/26.jpg",
    CareHome: "Olive Grove",

    ElderID: 3
  },
  {
    FirstName:"Elder4",
    LastName: "DeMero",
    Age: 10,
    Birthday: "10/27/2008",
    avatar_url: "https://d3iw72m71ie81c.cloudfront.net/gaurav.JPG",
    CareHome: "Golden Rose",
    ElderID: 4
  }
]

EmployeeList =[
  {
    FirstName: "Employee1",
    LastName: "Thomas",
    Age: 20,
    Birthday: "10/27/1998",
    CareHome: "Olive Grove",
    Position: "Volunteer",
    EmployeeID: 1
  },
  {
    FirstName: "Employee2",
    LastName: "Peterson",
    Age: 15,
    Birthday: "10/27/2003",
    CareHome: "Golden Rose",
    Position: "Volunteer",
    EmployeeID: 2
  },
  {
    FirstName:"Employee3",
    LastName: "Simedru",
    Age: 30,
    Birthday: "10/27/1988",
    CareHome: "Olive Grove",
    Position: "Care Giver",
    EmployeeID: 3
  },
  {
    FirstName:"Employee4",
    LastName: "Taseen",
    Age: 25,
    Birthday: "10/27/1993",
    CareHome: "Golden Rose",
    Position: "Regional Manager",
    EmployeeID: 4
  }

]

CareHomeList =[
  {
    Name:"Golden Rose",
    Address:"21212 S 99th Avenue",
    CareHomeID: 1
  },
  {
    Name:"Olive Grove",
    Address:"10101 N 100th Avenue",
    CareHomeID: 2
  }
]

{/*'''''''''Conditional Rendering''''''''''*/}
WhatToRender = ""

function WhichListToRender()
{
    if (WhatToRender == "Elder")
    {
        return ElderList
    }
    else if (WhatToRender == "Employee")
    {
        return EmployeeList
    }
    else if (WhatToRender == "CareHome")
    {
        return CareHomeList
    }
}

{/* FOR XIAOFENG - RENDERING HOME SCREENS
renderEldersButton()
{
    //render button code
}
renderRequestsButton()
{

}
renderEmployeesButton()
{
}
renderCareHomesButton()
{
}
renderAccountSettingsButton()
{
}

function RenderHomeScreen()
{
    if (UserType == "Chief Admin")
    {
        renderEldersButton()
        renderRequestsButton()
        renderEmployeesButton()
        renderCareHomesButton()
    }
    else if (UserType == "Regional Manager")
    {
        renderEldersButton()
        renderRequestsButton()
        renderEmployeesButton()
    }
    else if (UserType == "Care Giver")
    {
        renderEldersButton()
        renderRequestsButton()
    }
    renderAccountSettingsButton()
}
*/}

function RenderLists(item, navigation)
{
    if (WhatToRender == "Elder")
    {
        return (
            <ListItem
                avatar={{uri: item.avatar_url}}
                title={`Name: ${item.FirstName} ${item.LastName}`}
                subtitle={`Age: ${item.Age} | Care Home: ${item.CareHome}`}
                button onPress={() => navigation.navigate('Details',{ObjectType:'Elder',item:item})}
            />
        );
    }
    else if (WhatToRender == "Employee")
    {
        return (
            <ListItem
                title={`Name: ${item.FirstName} ${item.LastName}`}
                subtitle={`Job Title: ${item.Position}  Care Home: ${item.CareHome}`}
                button onPress={() => navigation.navigate('Details',{ObjectType:'Employee',item:item})}
            />
        );
    }
    else if (WhatToRender == "CareHome")
    {
        return (
            <ListItem
                title={`Care Home Name: ${item.Name}`}
                subtitle={`Address: ${item.Address}`}
                button onPress={() => navigation.navigate('Details',{ObjectType:'CareHome',item:item})}
            />
        );
    }
}

function RenderDetails(ObjectType, item)
{
    if (ObjectType == "Elder")
    {
        return (
            <View>
                <Text>FirstName: {item.FirstName}</Text>
                <Text>LastName: {item.LastName}</Text>
                <Text>ObjectType: {ObjectType}</Text>
                <Text>Age: {item.Age}</Text>
                <Text>Birthday: {item.Birthday}</Text>
                <Text>CareHome: {item.CareHome}</Text>
                <Text>EmployeeID: {item.EmployeeID}</Text>
            </View>
        );
    }
    else if (ObjectType == "Employee")
    {
        return (
            <View styles={{}}>
                <Text>FirstName: {item.FirstName}</Text>
                <Text>LastName: {item.LastName}</Text>
                <Text>ObjectType: {ObjectType}</Text>
                <Text>Age: {item.Age}</Text>
                <Text>Birthday: {item.Birthday}</Text>
                <Text>CareHome: {item.CareHome}</Text>
                <Text>Position: {item.Position}</Text>
                <Text>EmployeeID: {item.EmployeeID}</Text>
            </View>
        );
    }
    else if (ObjectType == "CareHome")
    {
        return (
            <View>
                <Text>Name: {item.Name}</Text>
                <Text>Address: {item.Address}</Text>
                <Text>ObjectType: {ObjectType}</Text>
                <Text>CareHomeID: {item.CareHomeID}</Text>
            </View>
        );
    }


}


function SetWhatToRender(ButtonSelected)
{
    WhatToRender = ButtonSelected
    Refresh()
}


{/*'''''''''This is the rendered class''''''''''*/}
class ListViewRender extends Component {
  constructor(props)
  {
    super(props);

    this.state = {
      data: []
    };
  }

  componentWillMount()
  {
    global.Refresh = () =>
    {
        this.forceUpdate();
    };
  }

  render()
  {
    return (
      <List>
        <View style={styles.buttonContainer}>
            <Button
                onPress={() => SetWhatToRender("Elder")}
                title="List Elders"
            />
            <Button
                onPress={() => SetWhatToRender("Employee")}
                title="List Employees"
            />
            <Button
                onPress={() => SetWhatToRender("CareHome")}
                title="List Care Homes"
            />
            {/* FOR TASEEN - Pop-Up Alerts
            <Button
                onPress={() => Alert.alert("YOU CLICKED THIS BUTTON")}
                title="ALERT"
            />
            */}
        </View>

        <FlatList
          data = {WhichListToRender()}
          renderItem = {({ item }) => (
                RenderLists(item,this.props.navigation)
          )}
        />
      </List>
    );
  }
}

class DetailViewRender extends Component {

    render()
    {
        const ObjectType = this.props.navigation.getParam('ObjectType');
        const item = this.props.navigation.getParam('item');
        return(
            RenderDetails(ObjectType, item)
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
});

export default createStackNavigator(
  {
    List:
    {
        screen: ListViewRender,
        navigationOptions: () => ({header: null})
    },
    Details:
    {
        screen: DetailViewRender,
        navigationOptions: () => ({header: null})
    }
  },
  {
    initialRouteName: 'List',
  }
);
