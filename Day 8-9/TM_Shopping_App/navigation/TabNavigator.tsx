import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import BasketIcon from "../components/BasketIcon";
import HomeIcon from "../components/HomeIcon";
import HomeScreen from "../screens/HomeScreen";
import ProductScreen from "../screens/ProductScreen";

export type TabStackPramsList = {
  HomeTab: undefined;
  BasketTab: undefined;
};

export type HomeStackParamList = {
  HomeScreen: undefined;
  ProductScreen: { category: string };
};

export type BasketStackParamList = {};

const Tab = createBottomTabNavigator<TabStackPramsList>();
const Stack = createNativeStackNavigator<
  HomeStackParamList & BasketStackParamList
>();

const HomeStack = () => {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      <Stack.Screen name="HomeScreen" component={HomeScreen} />
      <Stack.Screen
        name="ProductScreen"
        component={ProductScreen}
      ></Stack.Screen>
    </Stack.Navigator>
  );
};

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
        component={HomeStack}
        options={{
          tabBarIcon: BasketIcon,
        }}
      />
    </Tab.Navigator>
  );
};

export default TabNavigator;
