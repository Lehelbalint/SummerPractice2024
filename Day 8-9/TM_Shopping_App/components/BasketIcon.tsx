import Icon from "./Icon";
import { StyleSheet } from "react-native";

const BasketIcon = () => (
  <Icon source={require("../assets/icon_shopping.png")} style={styles.icon} />

);

const styles = StyleSheet.create({
  icon: {
    width: "20%",
    height: 24,
  },
});

export default BasketIcon;
