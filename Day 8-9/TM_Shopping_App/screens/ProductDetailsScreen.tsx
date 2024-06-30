import { Button, Image, SafeAreaView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { COLORS, STYLES } from "../constants";
import { RouteProp, useNavigation, useRoute } from "@react-navigation/native";
import { HomeStackParamList } from "../navigation/TabNavigator";
import useFetch from "../hooks/useFetch";
import { BasketProduct, Product } from "../types/Product";
import Icon from "../components/Icon";

import RatingIcon from "../components/RatingIcon";
import AddToCartButton from "../components/AddToCartButton";
import React, { useEffect, useState } from "react";
import CounterItem from "../components/CounterItem";
import getProductQuantity from "../hooks/useExistInLocal";
import AsyncStorage from "@react-native-async-storage/async-storage";
import BackIcon from "../components/BackIcon";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";

const storeProduct = async (key: string, product: BasketProduct) => {
    try {
      const jsonValue = JSON.stringify(product);
      await AsyncStorage.setItem(key, jsonValue);
    } catch (e) {
      console.error('Error storing product', e);
    }
  };

  const getProduct = async (key: string) => {
    try {
      const jsonValue = await AsyncStorage.getItem(key);
      return jsonValue != null ? JSON.parse(jsonValue) : null;
    } catch (e) {
      console.error('Error fetching product', e);
    }
  };
const ProductDetailsScreen = () => {
    const navigation =
    useNavigation<NativeStackNavigationProp<HomeStackParamList>>();

    type ProductDetailsScreenProps = RouteProp<HomeStackParamList, "ProductDetailsScreen">;
    const param = useRoute<ProductDetailsScreenProps>().params;
    const {data} = useFetch<Product>({endpoint: `products/${param.id}`,});
    const [counter, setCounter] = useState(1);
    const [totalPrice, setTotalPrice] = useState(1);
    useEffect(() => {
        const price = Number(data?.price)
        setTotalPrice(counter*price)
    },[][counter])
    
    
    
    const AvailableOnStock = () =>
        {
            //console.log(Number(data?.stock))
            if (Number(data?.stock)>0)
                {
                    return(
                        <Text style={{fontSize: 16, fontWeight: "bold"}}>Available in stock</Text>
                    )
                }
            else {
                return(
                    <Text style={styles.textTitle}>Stock out</Text>
                )
            }
        }
    //console.log(data)
    return (
      <SafeAreaView style={styles.safeArea}>
        
         <Image style={{width: "auto", height: 250, borderRadius: 10, overflow: "hidden"}} source={{ uri: data?.images[0] }} />
         <TouchableOpacity  style={{ position: "absolute",}} onPress={() => navigation.goBack()} >
        <BackIcon/>
        </TouchableOpacity>   
        <View style={styles.detailsCard}>
            <View>
            <Text style={styles.textTitle}>{data?.title}</Text>
            <Text style={styles.textDescription}>{data?.category}</Text>
            <View style={{flexDirection: 'row', justifyContent:"space-between"}}>
            <View style={{ flexDirection: 'row', marginTop: 15}}>
            <View><RatingIcon/></View>
            <View><Text>{data?.rating} (ReviewScore)</Text></View>       
            </View>
            <View style={{flexDirection: "column"}}>
                <View style={{marginLeft: 50}}>
                <CounterItem counter={counter} setCounter={setCounter}/>
                </View>
                <Text style={{margin:5}}>{AvailableOnStock()}</Text>
            </View>
           </View>
            <Text style={styles.textTitle}>Brand</Text>
            <Text style={styles.textDescription}>{data?.brand}</Text>
            <Text style={styles.textTitle}>Description</Text>
            <Text style={styles.textDescription}>{data?.description}</Text>
            <View style={{ flexDirection: 'row',justifyContent:"space-between"}}>
            <View>
            <Text style={{marginTop: 10, fontWeight: "bold", color:"gray", fontSize:16}}>Total Price</Text>
            <Text style={styles.textTitle}>${totalPrice}</Text>
            </View>
            <View style={{ height: 60 , alignItems:"flex-end" }}>
            <TouchableOpacity onPress={async () =>
                { 
                    if(data){
                    const quantity =await  getProductQuantity(data?.id.toString())
                    //console.log(quantity )
                    const totalQuantity = counter + quantity
                    //console.log(counter)
                    const basketProduct : BasketProduct ={
                        id: data?.id,
                        brand: data?.brand,
                        title: data?.title,
                        images: data?.images,
                        price: data?.price, 
                        stock: data?.stock,
                        quantity: totalQuantity
                    }
                    storeProduct(data?.id.toString()  || "",basketProduct)
                }

                   
                }
            }>
            <AddToCartButton/>
            </TouchableOpacity>
            </View>
            </View>
            </View>
          
        </View>
      </SafeAreaView>
    );
  };
  

  
const styles = StyleSheet.create({
    safeArea: {
    ...STYLES.mainScreen,
    },
    backIcon: { marginLeft: 15, marginTop: 15 },
    textTitle: {
        ...STYLES.textPrimary,
        marginTop: 15,
        marginBottom: 15
      },
      textDescription: {
        ...STYLES.textSecondary,
        textAlign: "justify",


      },
      
    
    detailsCard: {
    flex: 1,
    backgroundColor: COLORS.white,
    marginTop: -20,
    borderTopEndRadius: 20,
    borderTopLeftRadius: 20,
    shadowOpacity: 0.25,
    shadowRadius: 3.84,
    elevation: 5,
    paddingHorizontal: 20,
    paddingVertical: 10,

    },   
    ratingIcon: {
    width: 35,
    height: 35,
    tintColor: "orange",
    marginRight: 10,
    },
    reviewsWrapper: {
    flexDirection: "row",
    alignItems: "center",
    marginVertical: 15,
    },
    stockText: {
    fontWeight: "700",
    marginTop: 22,
    },
    
    cartButton: { width: 150, borderRadius: 20, marginTop: 20 },
    });
    export default ProductDetailsScreen;