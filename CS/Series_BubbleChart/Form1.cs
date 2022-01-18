using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...
namespace Series_BubbleChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl chart = new ChartControl();
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            // Create a series.
            // Specify its data source and data members.
            Series series = new Series("Champions League Statistics", ViewType.Bubble);
            series.DataSource = DataPoint.GetDataPoints();
            series.ArgumentDataMember = "GoalsScored";
            series.ValueDataMembers.AddRange(new string[] { "GoalsConceded", "Points" });
            // You can also call the SetBubbleDataMembers method to specify data members.
            //series.SetBubbleDataMembers("GoalsScored", "GoalsConceded", "Points");
            chart.Series.Add(series);

            // Enable point labels and format their text.
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series.Label.TextPattern = "{Country}";

            // Configure the bubble series appearance.
            BubbleSeriesView view = (BubbleSeriesView)series.View;
            view.AutoSize = false;
            view.MaxSize = 30;
            view.MinSize = 10;
            view.BubbleMarkerOptions.Kind = MarkerKind.Circle;
            view.ColorEach = true;

            // Fine-tune the whole range to avoid trimmed bubbles and redundant empty spaces on the chart.
            XYDiagram diagram = chart.Diagram as XYDiagram;
            diagram.AxisY.WholeRange.MaxValue = 165;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;

            // Specify titles.
            diagram.AxisX.Title.Text = "Goals Scored";
            diagram.AxisY.Title.Text = "Goals Conceded";
            chart.Titles.Add(new ChartTitle { Text = "Champions League Statistics by Country" });

            // Disable the legend.
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
        }
    }
    public class DataPoint {
        public string Country { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Points { get; set; }
        public DataPoint(string country, int goalsScored, int goalsConceded, int points) {
            this.Country = country;
            this.GoalsScored = goalsScored;
            this.GoalsConceded = goalsConceded;
            this.Points = points;
        }
        public static List<DataPoint> GetDataPoints() {
            List<DataPoint> data = new List<DataPoint> {
                new DataPoint("Netherlands", 37, 51, 36),
                new DataPoint("Russia", 40, 67, 43),
                new DataPoint("Portugal", 75, 92, 89),
                new DataPoint("France", 113, 103, 88),
                new DataPoint("Italy", 122, 96, 139),
                new DataPoint("Germany", 158, 128, 135),
                new DataPoint("Spain", 214, 120, 220),
                new DataPoint("England", 248, 152, 232)
            };
            return data;
        }
    }
}