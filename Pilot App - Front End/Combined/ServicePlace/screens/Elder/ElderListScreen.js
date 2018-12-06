import React, { Component } from "react";
import { View, Text, FlatList, Alert, TouchableOpacity, StyleSheet, Button } from "react-native";
import { List, ListItem } from "react-native-elements";

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

function RenderLists(item, navigation)
{
    return (
        <ListItem
            key={item.ElderID}
            avatar={{uri: item.avatar_url}}
            title={`Name: ${item.FirstName} ${item.LastName}`}
            subtitle={`Age: ${item.Age} | Care Home: ${item.CareHome}`}
            button onPress={() => navigation.navigate('ElderDetailS',{item:item})}
        />
    );
}

class ElderListScreen extends Component {
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
          data = {ElderList}
          renderItem = {({ item }) => (
                RenderLists(item,this.props.navigation)
          )}
        />
      </List>
    );
  }
}
export default ElderListScreen;

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
