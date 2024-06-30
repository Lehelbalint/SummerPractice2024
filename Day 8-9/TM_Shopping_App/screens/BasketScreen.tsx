import AsyncStorage from "@react-native-async-storage/async-storage";
import { FlatList, Image, SafeAreaView, ScrollView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { BasketProduct } from "../types/Product";
import React, { useCallback, useEffect, useState } from "react";
import { useFocusEffect, useNavigation } from "@react-navigation/native";
import { COLORS, STYLES } from "../constants";
import BackIcon from "../components/BackIcon";
import newCounterItem from "../components/newCounterItem";
import NewCounterItem from "../components/newCounterItem";
import BasketItem from "../components/BasketItem";
import CheckOutButton from "../components/CheckoutButton";
import AddToCartButton from "../components/AddToCartButton";
import Icon from "../components/Icon";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";
import { BasketStackParamList } from "../navigation/TabNavigator";

const getTotalPrice = (cartData: BasketProduct[] ) =>{
  let totalPrice = 0
  cartData.forEach(item => {
      totalPrice = totalPrice + item.price * item.quantity
  });
  return totalPrice as number
}
const getTotalProducts = (cartData: BasketProduct[] ) =>{
  let totalPrice = 0
  cartData.forEach(item => {
      totalPrice = totalPrice + item.quantity
  });
  return totalPrice as number
}


const getAllData = async (): Promise<{ key: string, value: BasketProduct }[]> => {
  try {
    const keys = await AsyncStorage.getAllKeys();
    const result = await AsyncStorage.multiGet(keys);
    return result.map(([key, value]) => ({ key, value: JSON.parse(value || "") as BasketProduct }));
  } catch (e) {
    console.error('Error fetching data', e);
    return [];
  }
};

const BasketScreen: React.FC = () => {
  const [cartData, setCartData] = useState<BasketProduct[]>([]);
  const [totalPrice, setTotalPrice] = useState<number>(1);
  const [totalProducts, setTotalProducts] = useState<number>(1);
  const navigation =
  useNavigation<NativeStackNavigationProp<BasketStackParamList>>();
  const fetch = async () => {
    try {
      const response = await getAllData();
      if (response) {
        const formattedProducts = response.map((item) => ({
          id: Number(item.key),
          brand: item.value.brand,
          images: item.value.images,
          price: item.value.price,
          quantity: item.value.quantity,
          stock: item.value.stock,
          title: item.value.title,
        }));
        console.log(formattedProducts);
        await setCartData(formattedProducts);
        setTotalPrice(getTotalPrice(cartData))
      }
    } catch (error) {
      console.error('Error fetching data', error);
    }
  };
  useEffect(() => {
    if (cartData.length > 0) {
      const totalPrice = getTotalPrice(cartData);
      setTotalPrice(totalPrice);
      setTotalProducts(getTotalProducts(cartData))
    }
  }, [cartData]);

  const fetchData = useCallback(() => {
    fetch();
    
  }, []);
  

  useFocusEffect(fetchData);

  return (
    <SafeAreaView>
      <ScrollView>
      <View style={{ justifyContent: "flex-start", alignItems: "flex-start" }}>
        <Text style={styles.title}>My Cart</Text>
      </View>
      <View style={{justifyContent: "space-between", flexDirection:"column"}}>
      <FlatList
        data={cartData}
        renderItem={({ item }) => <BasketItem item={item} />}
        keyExtractor={item => item.id.toString()}
        showsVerticalScrollIndicator={false}
      />
      <View style={{justifyContent:"space-between", flexDirection:"row", marginLeft:20}}>
      <Text style={styles.description}>Products: {totalProducts}</Text>
      <Text style={styles.textPrice}>Total:{totalPrice}</Text>
      </View>
      </View>
      <TouchableOpacity onPress={() => navigation.navigate("DetailsScreen")} style={{backgroundColor:"black", margin:15, height:40, borderRadius:5,flexDirection:"row", justifyContent:"center" }}>
      <Text style={{marginRight:5, fontSize:17,  color: "white", alignSelf:"center"}} >Proceed to Checkout</Text>
      <Icon source={require("../assets/icon_right.png")} style={{tintColor: "white", width: 20, height: 20, marginTop: 10}}/>
      </TouchableOpacity>
      </ScrollView>
    </SafeAreaView>
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
    fontSize: 25,
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

export default BasketScreen


  