import React from 'react'
import {Alert, StyleSheet, Text, View, TouchableOpacity, FlatList, Button} from 'react-native'

class MultiTypeScreen extends React.Component
{
    constructor()
    {
        super();
    }
    
    //This Function will take in the selcted Button Type
    //And navigate to that respective Home Screen
    NavigateToScreen(Type, Account)
    {
       //Chief Administrator
        if (Type == "Administrator")
        {
            this.props.navigation.navigate("AdminHomeS",{Account : Account});
        }
        //Regional Manager
        else if (Type == "Manager")
        {
            this.props.navigation.navigate("ManagerHomeS",{Account : Account});
        }
        //CareGiver / Volunteer
        else if (Type == "Volunteer")
        {
            this.props.navigation.navigate("EmployeeHomeS",{Account : Account});
        }
        //Elder
        else if (Type == "Elder")
        {
            this.props.navigation.navigate("ElderHomeS")
        }
        //Family Member
        else if(Type == "Family")
        {
            alert("Render Family Page");
        }
    }
    
    render()
    {
        const { navigation } = this.props;
        const Account = navigation.getParam('Account');
        var AccountTypes = Account.UserType.split(',');
        listItems = AccountTypes.map((Type) => 
            <View style={{padding: 20}} key={Type.toString()}>
                <Button
                    title={Type}
                    onPress = {() => this.NavigateToScreen(Type, Account)}
                />
            </View>);
        
        return(
            <View style={{flex:1}}>
                <Text style={{fontSize: 28, textAlign: 'center'}}>Which Account Type would you like to log into?</Text>
                {listItems}
            </View>
        );
    }
}
export default MultiTypeScreen;

const styles = StyleSheet.create(
{
    container: 
    { 
        flex: 1,
        flexDirection:'column',
        backgroundColor: '#78909C',
        alignItems: 'center',
        paddingTop:60,
    },
    inputFields:
    { 
        width: '95%',
        alignItems:'center' 
    },
    textFields:
    {
        backgroundColor:'rgba(255,255,255,0.7)',
        height: 40,
        textAlign: 'center',
        margin: 15,
        borderRadius: 160,
        width:'80%'
    },
    touchBtn:
    {
        backgroundColor: '#DDDDDD',
        padding: 10,
        borderRadius: 10,
        margin: 10,
        width:'40%',
        alignItems:'center',
    },
});