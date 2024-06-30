import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import BasketIcon from "../components/BasketIcon";
import HomeIcon from "../components/HomeIcon";
import HomeScreen from "../screens/HomeScreen";
import ProductScreen from "../screens/ProductScreen";
import ProductDetailsScreen from "../screens/ProductDetailsScreen";
import BasketScreen from "../screens/BasketScreen";
import DetailsScreen from "../screens/DetailsScreen";
import { Details } from "../types/Product";
import CheckoutScreen from "../screens/CheckoutScreen";

export type TabStackPramsList = {
  HomeTab: undefined;
  BasketTab: undefined;
};

export type HomeStackParamList = {
  HomeScreen: undefined;
  ProductScreen: { category: string };
  ProductDetailsScreen: {id: number};
};

export type BasketStackParamList = {
  BasketScreen : undefined;
  DetailsScreen : undefined;
  CheckoutScreen : { details: Details}
};

const Tab = createBottomTabNavigator<TabStackPramsList>();
const Stack = createNativeStackNavigator<
  HomeStackParamList & BasketStackParamList
>();

const HomeStack = () => {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      <Stack.Screen name="HomeScreen" component={HomeScreen} />
      <Stack.Screen name="ProductScreen"component={ProductScreen}></Stack.Screen>
      <Stack.Screen name="ProductDetailsScreen" component={ProductDetailsScreen}></Stack.Screen>
    </Stack.Navigator>
  );
};
const BasketStack = () =>{
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      <Stack.Screen name="BasketScreen" component={BasketScreen} />
      <Stack.Screen name="DetailsScreen" component={DetailsScreen} />
      <Stack.Screen name="CheckoutScreen" component={CheckoutScreen} />
    </Stack.Navigator>
  );
}

const TabNavigator = () => {
  return (
    <Tab.Navigator screenOptions={{ headerShown: false }}>
      <Tab.Screen
        name="HomeTab"
        component={HomeStack}
        options={{
          tabBarIcon: HomeIcon,
        }}
      />
      <Tab.Screen
        name="BasketTab"
        component={BasketStack}
        options={{
          tabBarIcon: BasketIcon,
        }}
      />
    </Tab.Navigator>
  );
};

export default TabNavigator;
