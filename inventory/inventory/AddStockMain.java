package com.dxc.inventory;

import java.sql.SQLException;
import java.util.Scanner;

public class AddStockMain {
	public static void main(String[] args) {
		//FIrst step
		Scanner sc= new Scanner(System.in);
		StockDAO dao= new StockDAO();
		Stock stock=new Stock();
		System.out.println("Enter Item Name...");
		stock.setItemName(sc.nextLine());
		System.out.println("Enter Price...");
		stock.setPrice(Integer.parseInt(sc.nextLine()));
		System.out.println("enter Quantity Avail ");
		stock.setQuantityAvail(Integer.parseInt(sc.nextLine()));
		try {
			System.out.println(dao.generateStockId());
			String stockid = dao.generateStockId();
			stock.setStockId(stockid);
			System.out.println(dao.createStock(stock));
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		
		
		
	}
	

}
