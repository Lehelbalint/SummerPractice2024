import { StyleSheet, Text, View } from "react-native";
import Icon from "./Icon";

const CheckOutButton = () => (
    <View style={styles.iconButton}>
    <Text style={{color:"black"}}>Proceed to Checkout</Text>
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
        width:200, borderRadius: 100, marginTop: 20 , flex: 1, flexDirection: "row", alignItems: "center" 
    }
  });
  
  export default CheckOutButton;