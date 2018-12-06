import React from 'react';
import {StyleSheet, View, FlatList, Text} from 'react-native';
var arrays = [
  { "name":"Elder1", "food": "Spaghetti", "key": '1'},
  { "name":"Elder2", "food": "Banana", "key": '2'},
  { "name":"Elder31","food": "Apples", "key": '10'},
  { "name":"Elder41","food": "Juice", "key": '212'},
];

class FlatListItem extends React.Component {
  render(){
    return(
      <View style={styles.blue}>
      <Text style={styles.blueS}>Name:{this.props.itemPass.name}</Text>
      <Text style={styles.blueS}>Preferred Food: {this.props.itemPass.food}</Text>
      </View>
    );
  }
}
// Insert Server side fetch to get data
class ElderViewScreen extends React.Component { 
  render() {
    return (
    <View style={styles.container}>
      <Text>Elderly List View</Text>
      <FlatList data={arrays} 
      renderItem={({item,index}) =>{ return(<FlatListItem itemPass={item} indexPass={index}></FlatListItem>);}}
      ></FlatList>
    </View>
    );
  }
}

export default ElderViewScreen;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'gray',
   },
   blue:
   {
     fontSize: 34,
   },
   blueS:
   {
     fontSize: 34,
   }

});


