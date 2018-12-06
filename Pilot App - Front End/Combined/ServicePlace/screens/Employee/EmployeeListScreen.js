import React, { Component } from "react";
import { View, Text, FlatList, Alert, TouchableOpacity, StyleSheet, Button } from "react-native";
import { List, ListItem } from "react-native-elements";

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

function RenderLists(item, navigation)
{
    return (
        <ListItem
            key={item.EmployeeID}
            title={`Name: ${item.FirstName} ${item.LastName}`}
            subtitle={`Age: ${item.Age} | Care Home: ${item.CareHome}`}
            button onPress={() => navigation.navigate('EmployeeDetailS',{item:item})}
        />
    );
}

class EmployeeListScreen extends Component 
{
  constructor(props)
  {
    super(props);

    this.state = {
      data: []
    };
  }

  render()
  {
    return (
      <List>
        <FlatList
          data = {EmployeeList}
          renderItem = {({ item }) => (
                RenderLists(item,this.props.navigation)
          )}
        />
      </List>
    );
  }
}
export default EmployeeListScreen;

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
