import java.util.*;
import java.util.stream.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.table.*;

class JFCMVCTest{

	static class MainFrame extends JFrame{

		JTextField input = new JTextField();
		JButton submit = new JButton("Register");
		JTable view = new JTable();

		MainFrame(){
			super("Welcome Visitor");
			setSize(300, 300);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			setUndecorated(true);
			rootPane.setWindowDecorationStyle(JRootPane.FRAME);
			JPanel top = new JPanel(new BorderLayout());
			top.add(new JLabel("Name:"), BorderLayout.WEST);
			top.add(input);
			top.add(submit, BorderLayout.EAST);
			add(top, BorderLayout.NORTH);
			add(new JScrollPane(view));
			submit.addActionListener(new VisitorInputController());
		}

		class VisitorTableModel extends AbstractTableModel{
			
			private ArrayList<Visitor> store = new ArrayList<>();

			VisitorTableModel(){
				store.add(new Visitor("Jack"));
				store.add(new Visitor("Jill"));
			}

			@Override
			public int getColumnCount(){
				return 3;
			}

			@Override
			public String getColumnName(int i){
				String[] entries = {"Name", "Visit Count", "Last Visit"};
				return entries[i];
			}

			@Override
			public Class getColumnClass(int i){
				Class[] entries = {String.class, Integer.class, Date.class};
				return entries[i];
			}

			@Override
			public int getRowCount(){
				return store.size();
			}

			@Override
			public Object getValueAt(int i, int j){
				Visitor visitor = store.get(i);
				Object[] entries = {visitor.name, visitor.frequency, visitor.recent};
				return entries[j];
			}

			public void updateFor(String id){
				Optional<Visitor> entry = store.stream().filter(v -> v.name.equals(id)).findFirst();
				if(entry.isPresent()){
					Visitor visitor = entry.get();
					visitor.visit();
				}else{
					store.add(new Visitor(id));
				}
				fireTableDataChanged();
			}
		}

		class VisitorInputController implements ActionListener{

			VisitorTableModel model = new VisitorTableModel();

			VisitorInputController(){
				view.setModel(model);
			}

			public void actionPerformed(ActionEvent e){
				String id = input.getText();
				if(id.length() > 0)
					model.updateFor(id);
			}
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
	}
}

