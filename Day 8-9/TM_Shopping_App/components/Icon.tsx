import { Image, ImageSourcePropType } from "react-native";
import { ImageStyle } from "react-native";

type Props = {
  source: ImageSourcePropType;
  style: ImageStyle;
};

const Icon = ({ source, style }: Props) => {
  return <Image source={source} style={style} />;
};
export default Icon;
