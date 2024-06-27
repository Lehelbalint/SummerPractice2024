import {
  SafeAreaView,
  Text,
  StyleSheet,
  FlatList,
  TouchableOpacity,
  View,
} from "react-native";
import { COLORS, STYLES } from "../constants";
import useFetch from "../hooks/useFetch";
import { useNavigation } from "@react-navigation/native";
import { NativeStackNavigationProp } from "@react-navigation/native-stack";
import { HomeStackParamList } from "../navigation/TabNavigator";

const HomeScreen = () => {
  const { data } = useFetch<string[]>({ endpoint: "products/category-list" });

  const navigation =
    useNavigation<NativeStackNavigationProp<HomeStackParamList>>();

  const renderItem = ({ item }: { item: string }) => {
    return (
      <TouchableOpacity
        style={{ marginVertical: 5 }}
        onPress={() => navigation.navigate("ProductScreen", { category: item })}
        activeOpacity={0.8}
      >
        <View style={styles.container}>
          <Text style={styles.text}>{item}</Text>
          <View style={styles.dot}></View>
        </View>
      </TouchableOpacity>
    );
  };
  return (
    <SafeAreaView style={styles.safeArea}>
      <View style={{ marginLeft: 20, flex: 1, marginRight: 20 }}>
        <Text style={styles.title}>Categories</Text>
        {/* <Text
        style={{
          textAlign: "center",
        }}
      ></Text>
      {data?.map((item, index) => {
        return (
          <Text key={index} style={styles.text}>
            {item}
          </Text>
        );
      })} */}
        {data && (
          <FlatList
            data={data}
            renderItem={renderItem}
            showsVerticalScrollIndicator={false}
          />
        )}
      </View>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  safeArea: {
    ...STYLES.mainScreen,
  },

  container: {
    backgroundColor: COLORS.black,
    height: 60,
    borderRadius: 30,
    flexDirection: "row",
    justifyContent: "space-between",
    marginTop: 0,
    paddingHorizontal: 15,
    alignItems: "center",
  },

  category: {
    flex: 1,
    justifyContent: "space-between",
    flexDirection: "row",
    marginTop: 0,
    alignItems: "center",
  },
  title: {
    ...STYLES.textPrimary,
    marginVertical: 10,
  },

  dot: {
    height: 30,
    backgroundColor: COLORS.white,
    borderRadius: 100,
    width: 30,
  },

  text: {
    color: COLORS.white,
    textTransform: "capitalize",
    fontSize: 16,
    fontWeight: "bold",
  },
});

export default HomeScreen;
