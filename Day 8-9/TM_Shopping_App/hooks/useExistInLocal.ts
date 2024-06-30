import AsyncStorage from "@react-native-async-storage/async-storage";

const getProductQuantity = async (key: string) => {
    try {
       console.log(key)
      const jsonValue = await AsyncStorage.getItem(key);
      if (jsonValue !== null) {
        const product = JSON.parse(jsonValue);
        return product.quantity;
      } else {
        return 0;
      }
    } catch (e) {
      console.error('Error fetching product', e);
      return null;
    }
  };

export default getProductQuantity



