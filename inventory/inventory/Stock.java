package com.dxc.inventory;

public class Stock {
	private String stockId;
	private int price;
	private String itemName;
	private int quantityAvail;
	
	
	
	@Override
	public String toString() {
		return "Stock [stockId=" + stockId + ", price=" + price + ", itemName=" + itemName + ", quantityAvail="
				+ quantityAvail + "]";
	}



	public String getStockId() {
		return stockId;
	}



	public void setStockId(String stockId) {
		this.stockId = stockId;
	}



	public int getPrice() {
		return price;
	}



	public void setPrice(int price) {
		this.price = price;
	}



	public String getItemName() {
		return itemName;
	}



	public void setItemName(String itemName) {
		this.itemName = itemName;
	}



	public int getQuantityAvail() {
		return quantityAvail;
	}



	public void setQuantityAvail(int quantityAvail) {
		this.quantityAvail = quantityAvail;
	}



	public Stock(String stockId, int price, String itemName, int quantityAvail) {
		
		this.stockId = stockId;
		this.price = price;
		this.itemName = itemName;
		this.quantityAvail = quantityAvail;
	}



	public Stock() {
		
	}
	
	
	
	
}





	