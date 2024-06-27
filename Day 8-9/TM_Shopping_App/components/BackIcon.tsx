import { StyleSheet } from "react-native";
import Icon from "./Icon";

const BackIcon = () => (
  <Icon source={require("../assets/icon_back.png")} style={styles.icon} />
);

const styles = StyleSheet.create({
  icon: {
    width: 40,
    height: 40,
    backgroundColor: "black",
    tintColor: "white",
    margin: 2,
    borderRadius: 100,
  },
});

export default BackIcon;
