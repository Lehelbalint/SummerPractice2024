import {
  SafeAreaView,
  Text,
  StyleSheet,
  FlatList,
  TouchableOpacity,
  View,
  Image,
  Button,
} from "react-native";
import { COLORS, STYLES } from "../constants";
import useFetch from "../hooks/useFetch";
import { RouteProp, useNavigation, useRoute } from "@react-navigation/native";
import { HomeStackParamList } from "../navigation/TabNavigator";
import { Product, Products } from "../types/Product";
import BackIcon from "../components/BackIcon";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";

const ProductScreen = () => {
  type ProductScreenProps = RouteProp<HomeStackParamList, "ProductScreen">;
  const param = useRoute<ProductScreenProps>().params;
  const { data } = useFetch<Products>({
    endpoint: `products/category/${param.category}`,
  });
  const navigation =
    useNavigation<NativeStackNavigationProp<HomeStackParamList>>();

  const renderItem = ({ item }: { item: Product }) => {
    return (
      <TouchableOpacity style={styles.container}>
        <Image style={styles.image} source={{ uri: item.images[0] }} />
        <Text style={styles.textTitle}>{item.title}</Text>
        <Text style={styles.textDescription}>{item.brand}</Text>
        <Text style={styles.textPrice}>${item.price}</Text>
      </TouchableOpacity>
    );
  };
  //   console.log("data", data);
  return (
    <SafeAreaView style={styles.safeArea}>
      <TouchableOpacity
        onPress={() => navigation.navigate("HomeScreen")}
        style={{ width: 45 }}
      >
        <BackIcon />
      </TouchableOpacity>
      <Text style={styles.screenTitle}>{param.category}</Text>
      {data && (
        <FlatList
          numColumns={2}
          data={data.products}
          renderItem={renderItem}
          showsVerticalScrollIndicator={false}
        />
      )}
    </SafeAreaView>
  );
};
const styles = StyleSheet.create({
  safeArea: {
    ...STYLES.mainScreen,
  },
  emptySafeArea: {
    alignItems: "center",
    flex: 1,
    justifyContent: "center",
  },
  screenTitle: {
    ...STYLES.textPrimary,
    marginLeft: 5,
    marginBottom: 10,
  },
  container: {
    width: "50%",
    alignItems: "center",
    shadowColor: "#000",
    shadowOpacity: 0.15,
    shadowRadius: 3.84,
    elevation: 5,
  },
  image: {
    width: 150,
    height: 150,
    borderRadius: 10,
  },
  textContainer: { marginHorizontal: 10, alignItems: "center" },
  textTitle: {
    ...STYLES.textPrimary,
    marginTop: 5,
  },
  textDescription: {
    ...STYLES.textSecondary,
    textAlign: "justify",
  },
  textPrice: {
    ...STYLES.textPrimary,
    marginBottom: 20,
  },
  indicator: {
    alignSelf: "center",
  },
});

export default ProductScreen;
