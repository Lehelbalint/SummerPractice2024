import { Button, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import Icon from "./Icon";

const AddToCartButton = () => (
    <View style={styles.iconButton}>
    <Icon source={require("../assets/icon_shopping.png")} style={styles.icon} />
    <Text style={{color:"white"}}>Add to cart</Text>
    </View>
  );


  
  const styles = StyleSheet.create({
    icon: {
        width: 20,
        height: 20,
        backgroundColor: "black",
        tintColor: "white",
        margin: 2,
    },
    iconButton:
    {
        width:100, borderRadius: 100, marginTop: 20 , flex: 1, flexDirection: "row", backgroundColor: "black", alignItems: "center" 
    }
  });
  
  export default AddToCartButton;
  