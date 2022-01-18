Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

' ...
Namespace Series_BubbleChart

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new chart.
            Dim chart As ChartControl = New ChartControl()
            chart.Dock = DockStyle.Fill
            Me.Controls.Add(chart)
            ' Create a series.
            ' Specify its data source and data members.
            Dim series As Series = New Series("Champions League Statistics", ViewType.Bubble)
            series.DataSource = DataPoint.GetDataPoints()
            series.ArgumentDataMember = "GoalsScored"
            series.ValueDataMembers.AddRange(New String() {"GoalsConceded", "Points"})
            ' You can also call the SetBubbleDataMembers method to specify data members.
            'series.SetBubbleDataMembers("GoalsScored", "GoalsConceded", "Points");
            chart.Series.Add(series)
            ' Enable point labels and format their text.
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
            series.Label.TextPattern = "{Country}"
            ' Configure the bubble series appearance.
            Dim view As BubbleSeriesView = CType(series.View, BubbleSeriesView)
            view.AutoSize = False
            view.MaxSize = 30
            view.MinSize = 10
            view.BubbleMarkerOptions.Kind = MarkerKind.Circle
            view.ColorEach = True
            ' Fine-tune the whole range to avoid trimmed bubbles and redundant empty spaces on the chart.
            Dim diagram As XYDiagram = TryCast(chart.Diagram, XYDiagram)
            diagram.AxisY.WholeRange.MaxValue = 165
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
            ' Specify titles.
            diagram.AxisX.Title.Text = "Goals Scored"
            diagram.AxisY.Title.Text = "Goals Conceded"
            chart.Titles.Add(New ChartTitle With {.Text = "Champions League Statistics by Country"})
            ' Disable the legend.
            chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        End Sub
    End Class

    Public Class DataPoint

        Public Property Country As String

        Public Property GoalsScored As Integer

        Public Property GoalsConceded As Integer

        Public Property Points As Integer

        Public Sub New(ByVal country As String, ByVal goalsScored As Integer, ByVal goalsConceded As Integer, ByVal points As Integer)
            Me.Country = country
            Me.GoalsScored = goalsScored
            Me.GoalsConceded = goalsConceded
            Me.Points = points
        End Sub

        Public Shared Function GetDataPoints() As List(Of DataPoint)
            Dim data As List(Of DataPoint) = New List(Of DataPoint) From {New DataPoint("Netherlands", 37, 51, 36), New DataPoint("Russia", 40, 67, 43), New DataPoint("Portugal", 75, 92, 89), New DataPoint("France", 113, 103, 88), New DataPoint("Italy", 122, 96, 139), New DataPoint("Germany", 158, 128, 135), New DataPoint("Spain", 214, 120, 220), New DataPoint("England", 248, 152, 232)}
            Return data
        End Function
    End Class
End Namespace
