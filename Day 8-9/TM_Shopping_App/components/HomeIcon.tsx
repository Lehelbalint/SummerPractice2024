import Icon from "./Icon";
import { StyleSheet } from "react-native";

const HomeIcon = () => (
  <Icon source={require("../assets/icon_home.png")} style={styles.icon} />
);

const styles = StyleSheet.create({
  icon: {
    width: 24,
    height: 24,
  },
});

export default HomeIcon;
