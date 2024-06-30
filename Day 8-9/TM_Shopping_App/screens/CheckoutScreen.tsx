
import { RouteProp, useFocusEffect, useNavigation, useRoute } from "@react-navigation/native";
import React, { useCallback, useEffect, useState } from "react";
import { FlatList, Image, Modal, SafeAreaView, StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { BasketStackParamList } from "../navigation/TabNavigator";
import { COLORS, STYLES } from "../constants";
import BackIcon from "../components/BackIcon";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";
import { BasketProduct } from "../types/Product";
import AsyncStorage from "@react-native-async-storage/async-storage";
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

  const renderItem = ({ item }: { item: BasketProduct }) => {
    return (
        <View style={styles.productCard}>
         <Image style={{width:60, height: 60, borderRadius: 10, overflow: "hidden"}} source={{ uri: item.images[0] }} />
        <View style={{flexDirection: "column"}}>
        <Text style={styles.title}>{item.title}</Text>
        <Text style={styles.textDescription}>{item.brand}</Text>
        <Text style={styles.title}>${item.price * item.quantity}</Text>
        </View>
        </View>
    );
  };
  


const CheckoutScreen = () => {
    const [cartData, setCartData] = useState<BasketProduct[]>([]);
    const [totalPrice, setTotalPrice] = useState<number>(1);
    const [modalVisible, setModalVisible] = useState(false);

    type CheckoutScreenProps = RouteProp<BasketStackParamList, "CheckoutScreen">;
    const param = useRoute<CheckoutScreenProps>().params.details;

    const navigation =useNavigation<NativeStackNavigationProp<BasketStackParamList>>();

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
        }
      }, [cartData]);
    
      const fetchData = useCallback(() => {
        fetch();
        
      }, []);
      
      useFocusEffect(fetchData);
    
    return (
      <SafeAreaView style={styles.safeArea}>
            <TouchableOpacity onPress={()=> navigation.goBack()}>
            <BackIcon/>
            </TouchableOpacity>
          <Text style={styles.textTitle}>Delivery Address</Text>
          <View style={styles.addressCard}>
            <View style={{flexDirection:"row"}}>
                <Text>Full Name: </Text>
                <Text style={styles.highlight}>{param.fullName}</Text>
            </View>
            <View style={{flexDirection:"row"}}>
                <Text>Phone Number: </Text>
                <Text style={styles.highlight}>{param.phoneNumber}</Text>
            </View>
            <View style={{flexDirection:"row"}}>
                <Text>Email: </Text>
                <Text style={styles.highlight}>{param.email}</Text>
            </View>
            <View style={{flexDirection:"row"}}>
                <Text>City: </Text>
                <Text style={styles.highlight}>{param.city}</Text>
            </View>
            <View style={{flexDirection:"row"}}>
                <Text>Address: </Text>
                <Text style={styles.highlight}>{param.address}</Text>
            </View>
          </View>
          <View style={{justifyContent:"space-between", flexDirection:"column"}}>
          <FlatList
            data={cartData}
            renderItem={renderItem}
            showsVerticalScrollIndicator={false}
          />
          <View style={{flexDirection:"row", justifyContent:"space-between"}}>
          <View style={{ flexDirection: "column"}}>
            <Text style={styles.textDescription}>Total price</Text>
            <Text style={styles.title}>${totalPrice}</Text>
          </View>
          <View>
            <TouchableOpacity onPress={() => setModalVisible(true)} style={{backgroundColor:"black", width:165, height:40, borderRadius: 30, alignItems:"center"}}>
                <Text  style={{color:"white",marginTop:8, fontSize:17}}>Place Order</Text>
            </TouchableOpacity>
          </View>
          </View>
          </View>

          <Modal
      
        animationType="slide"
        transparent={true}
        visible={modalVisible}
        onRequestClose={() => {
          setModalVisible(!modalVisible);
        }}>
        <View   style={{width:"90%",marginTop:150, height:"50%", justifyContent: 'center',alignItems: 'center',marginLeft:20, backgroundColor:COLORS.grayLight, borderRadius:20}}>
          <View>
            <Text style={{fontSize:17}}>Your order has been sent</Text>
            <TouchableOpacity
              style={{ backgroundColor: "black", width:130, height:40, alignSelf:"center", alignContent:"center", borderRadius:10, marginTop:10 }}
              onPress={() => setModalVisible(!modalVisible)}>
              <Text  style={{ color: "white", alignSelf:"center", fontSize:17, marginTop:7}}>Go Back</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
      </SafeAreaView>
        
    );
  };
  const styles = StyleSheet.create({
    //renderItem
    
    productCard: {
    height: 80,
    marginVertical: 5,
    flexDirection: "row",
    paddingLeft: 10,
    gap: 10,
    alignItems: "center",
    backgroundColor: COLORS.white,
    borderRadius: 10,
    width: "100%",
    },
    
    textTitle: {
    ...STYLES.textPrimary,
    marginTop:5,
    marginBottom: 10
    },
    textDescription: {
    ...STYLES.textSecondary,
    },
    
    safeArea: {
    ...STYLES.mainScreen,
    backgroundColor: COLORS.grayLight,
    paddingHorizontal: 15,
    },
    title: {
    ...STYLES.textPrimary,
    },
    addressCard: {
    marginVertical: 5,
    paddingLeft: 10,
    paddingVertical: 20,
    gap: 10,
    backgroundColor: COLORS.white,
    borderRadius: 10,
    width: "100%",
    },
    
    thumbnail: {
    height: 50,
    borderRadius: 10,
    width: 50,
    },
    
    highlight: {
    fontWeight: "bold",
    },
    
    orderButton: { borderRadius: 20, width: "50%", alignSelf: "center" },
    });
export default CheckoutScreen