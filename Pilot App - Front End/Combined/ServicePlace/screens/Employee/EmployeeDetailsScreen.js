import React, { Component } from "react";
import { View, Text, FlatList, Alert, TouchableOpacity, StyleSheet, Button, Image } from "react-native";
import Divider from 'react-native-divider';

function RenderDetails(item)
{
    return (
        <View>
            <View style={styles.Header}>
              <Image
                style={{width: 80, height: 80}}
                source={{uri: item.avatar_url}}
              />
              
            </View>

            <Divider borderColor="black" color='black' orientation="center">
              <Text style={styles.HeaderText}>{item.FirstName} {item.LastName} </Text>
            </Divider>

            <View style={styles.Details}>
              <Text style={styles.DetailsText}>Age: {item.Age}</Text>
              <Text style={styles.DetailsText}>Birthday: {item.Birthday}</Text>
              <Text style={styles.DetailsText}>CareHome: {item.CareHome}</Text>
              <Text style={styles.DetailsText}>ElderID: {item.ElderID}</Text>
            </View>

            <View style={styles.Details}>
              <TouchableOpacity style={[styles.touchBtn,{width:'50%'}]}>
                <Text>Personal Information   ></Text>
              </TouchableOpacity>

              <TouchableOpacity style={[styles.touchBtn,{width:'50%'}]}>
                <Text>Family Members   ></Text>
              </TouchableOpacity>

              <TouchableOpacity style={[styles.touchBtn,{width:'50%'}]}>
                <Text>Requests   ></Text>
              </TouchableOpacity>
            </View>
        </View>
    );
}

class ElderDetailsScreen extends Component 
{

    render()
    {
        const item = this.props.navigation.getParam('item');
        return(
            RenderDetails(item)
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
  },
  HeaderText:
  {
    fontSize:30
  },
  Header:
  {
    flexDirection: 'row',
    justifyContent: 'center'
  },
  Details:
  {
    alignItems: 'center'
  },
  DetailsText:
  {
    fontSize:20,
  },
  touchBtn:{
    backgroundColor: '#DDDDDD',
    padding: 10,
    borderRadius: 10,
    margin: 10,
    alignItems:'center',
  },
});

export default ElderDetailsScreen;
