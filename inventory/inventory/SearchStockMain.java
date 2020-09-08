package com.dxc.inventory;

import java.sql.SQLException;
import java.util.Scanner;



public class SearchStockMain {
	public static void main(String[] args) {
		String stockId;
		Scanner sc = new Scanner(System.in);
		System.out.println("Enter Stock Id");
		stockId=sc.nextLine();
		StockDAO dao = new StockDAO();
		try {
			Stock stockFound = dao.searchStock(stockId);
			if (stockFound!=null) {
				System.out.println(stockFound);
			} else {
				
				System.out.println("stock id Does Not Exist...");
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}

