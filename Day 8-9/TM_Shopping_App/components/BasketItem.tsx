import { useState } from "react";
import { Image, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import NewCounterItem from "./newCounterItem";
import { BasketProduct } from "../types/Product";
import { COLORS, STYLES } from "../constants";
import DeleteIcon from "./DeleteIcon";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useNavigation } from "@react-navigation/native";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";
import { BasketStackParamList, HomeStackParamList } from "../navigation/TabNavigator";

interface BasketItemProps {
    item: BasketProduct;
  }
  
const BasketItem: React.FC<BasketItemProps> = ({ item }) => {
    const [counter, setCounter] = useState(item.quantity);
    const navigation =
    useNavigation<NativeStackNavigationProp<BasketStackParamList>>();

const deleteItem = async (key: string) => {
        try {
          await AsyncStorage.removeItem(key);
          navigation.replace('BasketScreen');
          console.log(`Deleted item with key '${key}' from AsyncStorage.`);
        } catch (error) {
          console.error(`Error deleting item from AsyncStorage`);
        }
      };
  
    return (
      <View style={styles.productContainer}>
        <Image style={styles.imageBackground} source={{ uri: item.images[0] }} />
        <View style={{ position: "absolute" }}>
        <TouchableOpacity onPress={async() =>await deleteItem(item.id.toString())} style={{ position: "absolute", marginLeft:260}}>
        <DeleteIcon/>
        </TouchableOpacity>
        <NewCounterItem initialCounter={counter} setCounter={setCounter} />
        </View>
        <View style={{justifyContent: "space-between", flexDirection:"row"}}>
        <Text style={{fontSize: 18,fontWeight: "800" , textTransform: "capitalize", color: COLORS.black,width:200}}>{item.title}</Text>
        <Text style={{  fontSize: 20,marginRight: 20,fontWeight: "800",color: COLORS.black,alignItems:"flex-end"}}>${item.quantity*item.price}</Text>
        </View>
        
        <Text style={styles.description}>{item.brand}</Text>
      </View>
    );
  };
  const styles = StyleSheet.create({
    //renderItem
    productContainer: {
        
    borderRadius: 20,
    marginHorizontal: 20,
    marginBottom: 20,
    },
    imageBackground: {
    height: 100,
    overflow: "hidden",
    borderRadius: 10,
    },
    deleteIcon: { alignSelf: "flex-end", marginTop: 10, marginRight: 10 },
    checkoutButton: { marginHorizontal: 20, marginVertical: 10 },
    quantityButton: { marginBottom: 10, marginLeft: 10 },
    
    textContainer: {
    flexDirection: "row",
    alignItems: "center",
    },
    textTitle: {
       
    ...STYLES.textPrimary,

    marginTop: 5,
    color: COLORS.black,
    },
    description: {
    marginBottom: 10,
    ...STYLES.textSecondary,
    },
    price: {
    fontSize: 20,
    marginRight: 20,
    fontWeight: "800",
    color: COLORS.white,
    },
    
    //
    
    safeArea: {
    ...STYLES.mainScreen,
    },
    emptySafeArea: {
    alignItems: "center",
    flex: 1,
    justifyContent: "center",
    },
    
    title: {
    ...STYLES.textPrimary,
    marginLeft: 20,
    marginVertical: 10,
    },
    
    totalPricesFlex: { flexDirection: "row", marginVertical: 10 },
    
    textTotal: {
    marginHorizontal: 20,
    fontSize: 16,
    color: COLORS.graySecondary,
    fontWeight: "600",
    flex: 1,
    },
    
    textPrice: {
    fontSize: 20,
    fontWeight: "bold",
    marginHorizontal: 20,
    },
    });


  export default BasketItem
  
  