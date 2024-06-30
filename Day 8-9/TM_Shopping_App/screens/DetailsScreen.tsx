import { useNavigation } from "@react-navigation/native";
import useFetch from "../hooks/useFetch";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";
import { BasketStackParamList } from "../navigation/TabNavigator";
import { Button, SafeAreaView, StyleSheet, Text, TextInput, TouchableOpacity, View } from "react-native";
import { COLORS } from "../constants";
import { useState } from "react";
import Icon from "../components/Icon";
import { Details } from "../types/Product";



const DetailsScreen = () => {

  const navigation =
    useNavigation<NativeStackNavigationProp<BasketStackParamList>>();
      
    const [formData, setFormData] = useState({
        name: '',
        phoneNumber: '',
        email: '',
        city: '',
        address: ''
      });
    
      const handleInputChange = (fieldName: string, value: string) => {
        setFormData({
          ...formData,
          [fieldName]: value
        });
      };
    
      const handleSubmit = () => {
        const details: Details = {
          fullName: formData.name,
          phoneNumber: formData.phoneNumber,
          email: formData.email,
          city: formData.city,
          address: formData.address
        };
        navigation.navigate("CheckoutScreen",{details: details as Details})  
      };

  
  return (
    <SafeAreaView style={styles.safeArea}>
    <Text style={styles.title}>Details</Text>
    <Icon source={require("../assets/icon_data.jpg")} style={styles.image}></Icon>
    <View>
      <TextInput
        style={styles.textInput}
        placeholder="Full Name"
        value={formData.name}
        onChangeText={(text) => handleInputChange('name', text)}
      />
      <TextInput
        style={styles.textInput}
        placeholder="Phone Number"
        keyboardType="phone-pad"
        value={formData.phoneNumber}
        onChangeText={(text) => handleInputChange('phoneNumber', text)}
      />
      <TextInput
        style={styles.textInput}
        placeholder="Email"
         onChangeText={(text) => handleInputChange('email', text)}
        keyboardType="email-address"
      />
      <TextInput
        style={styles.textInput}
        placeholder="City"
        value={formData.city}
        onChangeText={(text) => handleInputChange('city', text)}
      />
      <TextInput
        style={styles.textInput}
        placeholder="Address"
        value={formData.address}
        onChangeText={(text) => handleInputChange('address', text)}
      />
    </View>
    <View style={styles.buttonContainer}>
    <TouchableOpacity onPress={() =>navigation.goBack()} style={{width: 80}} >
      <Text style={{color:"lightgray",fontWeight:"bold", fontSize:16}}>Cancel</Text>
    </TouchableOpacity>
    <TouchableOpacity onPress={() =>handleSubmit()} style={{backgroundColor:"black",width:100,height:35,borderRadius: 5 , alignItems:"center", justifyContent:"center"}} >
      <Text style={{color: COLORS.white, fontSize:18, fontWeight:"bold", }}>Confirm</Text>
    </TouchableOpacity>
    </View>
    </SafeAreaView>
  );
};
  const styles = StyleSheet.create({
    safeArea: {
    backgroundColor: COLORS.white,
    flex: 1,
    },
    title: {
    marginVertical: 10,
    marginHorizontal: 20,
    fontWeight: "bold",
    fontSize: 22,
    },
    textInput: {
    backgroundColor: COLORS.white,
    marginHorizontal: 20,
    marginVertical: 5,
    paddingHorizontal: 10,
    paddingVertical: 15,
    borderRadius: 10,
    borderWidth: 1,
    borderColor: COLORS.grayLight,
    },
    
    image: {
    width: "90%",
    height: 180,
    marginHorizontal: 20,
    marginBottom: 10,
    borderRadius: 10,
    resizeMode: "contain",
    },
    
    buttonContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
    marginHorizontal: 20,
    marginVertical: 20,
    flex: 1,
    alignItems: "flex-end",
    },
    
    cancelButton: {
    width: 80,
    backgroundColor: COLORS.white,
    },
    
    confirmButton: {
    width: 100,
    },
    });
export default DetailsScreen    