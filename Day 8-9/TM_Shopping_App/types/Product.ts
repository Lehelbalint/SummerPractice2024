export type Product = {
  id: number;
  brand: string;
  category: string;
  description: string;
  discountPercentage: number;
  quantity?: number;
  images: string[];
  rating: number;
  thumbnail: string;
  stock: string;
  title: string;
  price: number;
};

export type Products = {
  products: Product[];
};

export type BasketProduct = {
  id: number,
  brand: string,
  title: string,
  images: string[],
  quantity: number,
  price: number,
  stock : string
}

export type Details = {
  fullName: string,
  phoneNumber: string,
  email: string,
  city: string,
  address: string
}
