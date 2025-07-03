using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowProgramming_Assignments
{
    public partial class TrainManagement : Form
    {
        private DataGridView dataGridView;
        private string xmlFilePath = "trainInfo.xml";
        private XmlDocument xmlDoc;

        public TrainManagement()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadTrainData();
        }

        private void InitializeDataGridView()
        {
            // DataGridView 생성 및 설정
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            dataGridView.DefaultCellStyle.Font = new Font("맑은 고딕", 9);
            dataGridView.AllowUserToAddRows = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;

            // 열 정의
            dataGridView.Columns.Add("trainNumber", "열차번호");
            dataGridView.Columns.Add("trainName", "열차명");
            dataGridView.Columns.Add("departure", "출발지");
            dataGridView.Columns.Add("arrival", "도착지");
            dataGridView.Columns.Add("departureTime", "출발");
            dataGridView.Columns.Add("arrivalTime", "도착");
            dataGridView.Columns.Add("duration", "소요시간(분)");
            dataGridView.Columns.Add("trainType", "열차종류");
            dataGridView.Columns.Add("adultPrice", "성인요금");

            // 열 너비 조정
            dataGridView.Columns["trainNumber"].Width = 80;
            dataGridView.Columns["trainName"].Width = 70;
            dataGridView.Columns["departure"].Width = 70;
            dataGridView.Columns["arrival"].Width = 70;
            dataGridView.Columns["departureTime"].Width = 80;
            dataGridView.Columns["arrivalTime"].Width = 80;
            dataGridView.Columns["duration"].Width = 90;
            dataGridView.Columns["trainType"].Width = 110;
            dataGridView.Columns["adultPrice"].Width = 80;

            groupBoxTrainList.Controls.Add(dataGridView);
        }

        private void LoadTrainData()
        {
            try
            {
                if (!File.Exists(xmlFilePath))
                {
                    MessageBox.Show($"XML 파일을 찾을 수 없습니다: {xmlFilePath}", "파일 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                dataGridView.Rows.Clear();

                XmlNodeList trainList = xmlDoc.GetElementsByTagName("train");
                HashSet<string> addedTrains = new HashSet<string>(); // 중복 제거를 위한 HashSet

                foreach (XmlNode train in trainList)
                {
                    // 단일 값만 추출
                    string trainNumber = GetNodeText(train, "trainNumber");

                    // 중복 체크 - 열차번호가 이미 추가된 경우 건너뛰기
                    if (!string.IsNullOrWhiteSpace(trainNumber) && addedTrains.Contains(trainNumber))
                    {
                        continue;
                    }

                    string trainName = GetNodeText(train, "trainName");
                    string departure = GetNodeText(train, "departure");
                    string arrival = GetNodeText(train, "arrival");
                    string departureTime = GetNodeText(train, "departureTime");
                    string arrivalTime = GetNodeText(train, "arrivalTime");
                    string duration = GetNodeText(train, "duration");
                    string trainType = GetNodeText(train, "trainType");

                    // pricing 노드가 있으면 그 안의 adultPrice, 없으면 바로 adultPrice 가져오기
                    string adultPrice = "";
                    XmlNode pricingNode = train["pricing"];
                    if (pricingNode != null)
                    {
                        adultPrice = GetNodeText(pricingNode, "adultPrice");
                    }
                    else
                    {
                        adultPrice = GetNodeText(train, "adultPrice");
                    }

                    // 필수 데이터가 모두 비어있으면 건너뛰기
                    if (string.IsNullOrWhiteSpace(trainNumber) &&
                        string.IsNullOrWhiteSpace(departure) &&
                        string.IsNullOrWhiteSpace(arrival))
                    {
                        continue;
                    }

                    // 유효한 데이터인 경우 추가
                    dataGridView.Rows.Add(
                        trainNumber,
                        trainName,
                        departure,
                        arrival,
                        departureTime,
                        arrivalTime,
                        duration,
                        trainType,
                        adultPrice
                    );

                    // 추가된 열차번호를 HashSet에 기록
                    if (!string.IsNullOrWhiteSpace(trainNumber))
                    {
                        addedTrains.Add(trainNumber);
                    }
                }

                lblStatus.Text = $"총 {dataGridView.Rows.Count}개의 열차 정보가 로드되었습니다.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"XML 데이터 로드 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNodeText(XmlNode parentNode, string nodeName)
        {
            return parentNode[nodeName]?.InnerText ?? "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TrainEditForm editForm = new TrainEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // 중복 체크
                string newTrainNumber = editForm.TrainData["trainNumber"];
                if (IsTrainNumberExists(newTrainNumber))
                {
                    MessageBox.Show($"열차번호 '{newTrainNumber}'이(가) 이미 존재합니다. 다른 열차번호를 사용해주세요.",
                        "중복 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AddTrainToXml(editForm.TrainData);
                LoadTrainData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("삭제할 열차를 선택해주세요.", "선택 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            string trainNumber = selectedRow.Cells["trainNumber"].Value?.ToString();
            string departure = selectedRow.Cells["departure"].Value?.ToString();
            string arrival = selectedRow.Cells["arrival"].Value?.ToString();

            // 예약된 좌석이 있는지 확인
            if (HasReservedSeats(trainNumber))
            {
                MessageBox.Show($"선택한 열차에 예약된 좌석이 있어 삭제할 수 없습니다.\n\n열차번호: {trainNumber}\n노선: {departure} → {arrival}\n\n모든 예약을 취소한 후 다시 시도해주세요.",
                    "삭제 불가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"선택한 열차를 삭제하시겠습니까?\n\n열차번호: {trainNumber}\n노선: {departure} → {arrival}",
                "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteTrainFromXml(trainNumber);
                LoadTrainData();
            }
        }

        private bool HasReservedSeats(string trainNumber)
        {
            try
            {
                XmlNode seatAvailabilityNode = xmlDoc.GetElementsByTagName("seatAvailability")[0];
                if (seatAvailabilityNode == null) return false;

                XmlNodeList dateNodes = seatAvailabilityNode.SelectNodes("date");

                foreach (XmlNode dateNode in dateNodes)
                {
                    XmlNodeList trainNodes = dateNode.SelectNodes($"train[@trainNumber='{trainNumber}']");
                    foreach (XmlNode trainNode in trainNodes)
                    {
                        string reservedSeats = trainNode.Attributes["reservedSeats"]?.Value ?? "0";
                        if (int.TryParse(reservedSeats, out int reserved) && reserved > 0)
                        {
                            return true; // 예약된 좌석이 있음
                        }
                    }
                }

                return false; // 예약된 좌석이 없음
            }
            catch (Exception ex)
            {
                MessageBox.Show($"예약 정보 확인 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // 오류 발생 시 안전을 위해 삭제 불가로 처리
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainData();
        }

        private bool IsTrainNumberExists(string trainNumber)
        {
            if (string.IsNullOrWhiteSpace(trainNumber))
                return false;

            try
            {
                XmlNodeList trainList = xmlDoc.GetElementsByTagName("train");
                foreach (XmlNode train in trainList)
                {
                    if (GetNodeText(train, "trainNumber") == trainNumber)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private Dictionary<string, string> GetTrainDataFromRow(DataGridViewRow row)
        {
            return new Dictionary<string, string>
            {
                ["trainNumber"] = row.Cells["trainNumber"].Value?.ToString() ?? "",
                ["trainName"] = row.Cells["trainName"].Value?.ToString() ?? "",
                ["departure"] = row.Cells["departure"].Value?.ToString() ?? "",
                ["arrival"] = row.Cells["arrival"].Value?.ToString() ?? "",
                ["departureTime"] = row.Cells["departureTime"].Value?.ToString() ?? "",
                ["arrivalTime"] = row.Cells["arrivalTime"].Value?.ToString() ?? "",
                ["duration"] = row.Cells["duration"].Value?.ToString() ?? "",
                ["trainType"] = row.Cells["trainType"].Value?.ToString() ?? "",
                ["adultPrice"] = row.Cells["adultPrice"].Value?.ToString() ?? ""
            };
        }

        private Dictionary<string, string> GetCompleteTrainDataFromXml(string trainNumber)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            try
            {
                XmlNodeList trainList = xmlDoc.GetElementsByTagName("train");

                foreach (XmlNode train in trainList)
                {
                    if (GetNodeText(train, "trainNumber") == trainNumber)
                    {
                        // 기본 필드들
                        data["trainNumber"] = GetNodeText(train, "trainNumber");
                        data["trainName"] = GetNodeText(train, "trainName");
                        data["departure"] = GetNodeText(train, "departure");
                        data["arrival"] = GetNodeText(train, "arrival");
                        data["departureTime"] = GetNodeText(train, "departureTime");
                        data["arrivalTime"] = GetNodeText(train, "arrivalTime");
                        data["duration"] = GetNodeText(train, "duration");
                        data["trainType"] = GetNodeText(train, "trainType");
                        data["routeID"] = GetNodeText(train, "routeID");
                        data["operatingDays"] = GetNodeText(train, "operatingDays");

                        // seats 정보
                        XmlNode seatsNode = train["seats"];
                        if (seatsNode != null)
                        {
                            data["totalSeats"] = GetNodeText(seatsNode, "totalSeats");
                            data["standardSeats"] = GetNodeText(seatsNode, "standardSeats");
                            data["specialSeats"] = GetNodeText(seatsNode, "specialSeats");
                        }
                        else
                        {
                            data["totalSeats"] = GetNodeText(train, "totalSeats");
                        }

                        // pricing 정보
                        XmlNode pricingNode = train["pricing"];
                        if (pricingNode != null)
                        {
                            data["adultPrice"] = GetNodeText(pricingNode, "adultPrice");
                            data["childPrice"] = GetNodeText(pricingNode, "childPrice");
                            data["infantPrice"] = GetNodeText(pricingNode, "infantPrice");
                            data["specialSeatSurcharge"] = GetNodeText(pricingNode, "specialSeatSurcharge");
                        }
                        else
                        {
                            data["adultPrice"] = GetNodeText(train, "adultPrice");
                            data["childPrice"] = GetNodeText(train, "childPrice");
                            data["infantPrice"] = GetNodeText(train, "infantPrice");
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"열차 데이터 로드 중 오류: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }

        private void AddTrainToXml(Dictionary<string, string> trainData)
        {
            try
            {
                XmlNode root = xmlDoc.DocumentElement;
                XmlElement trainElement = xmlDoc.CreateElement("train");

                bool isComplexStructure = trainData.ContainsKey("isComplexStructure") && trainData["isComplexStructure"] == "true";

                if (isComplexStructure)
                {
                    // 복잡한 구조로 XML 생성
                    // 기본 정보
                    AddSimpleElement(trainElement, "trainNumber", trainData);
                    AddSimpleElement(trainElement, "trainName", trainData);
                    AddSimpleElement(trainElement, "departure", trainData);
                    AddSimpleElement(trainElement, "arrival", trainData);
                    AddSimpleElement(trainElement, "departureTime", trainData);
                    AddSimpleElement(trainElement, "arrivalTime", trainData);
                    AddSimpleElement(trainElement, "duration", trainData);
                    AddSimpleElement(trainElement, "trainType", trainData);
                    AddSimpleElement(trainElement, "routeID", trainData);
                    AddSimpleElement(trainElement, "operatingDays", trainData);

                    // seats 섹션
                    if (trainData.ContainsKey("totalSeats") || trainData.ContainsKey("standardSeats") || trainData.ContainsKey("specialSeats"))
                    {
                        XmlElement seatsElement = xmlDoc.CreateElement("seats");
                        AddSimpleElement(seatsElement, "totalSeats", trainData);
                        AddSimpleElement(seatsElement, "standardSeats", trainData);
                        AddSimpleElement(seatsElement, "specialSeats", trainData);
                        trainElement.AppendChild(seatsElement);
                    }

                    // pricing 섹션
                    if (trainData.ContainsKey("adultPrice") || trainData.ContainsKey("childPrice") || trainData.ContainsKey("infantPrice"))
                    {
                        XmlElement pricingElement = xmlDoc.CreateElement("pricing");
                        AddSimpleElement(pricingElement, "adultPrice", trainData);
                        AddSimpleElement(pricingElement, "childPrice", trainData);
                        AddSimpleElement(pricingElement, "infantPrice", trainData);
                        AddSimpleElement(pricingElement, "specialSeatSurcharge", trainData);
                        trainElement.AppendChild(pricingElement);
                    }
                }
                else
                {
                    // 단순한 구조로 XML 생성
                    string[] simpleFields = { "trainNumber", "trainName", "departure", "arrival",
                                            "departureTime", "arrivalTime", "duration", "trainType",
                                            "totalSeats", "adultPrice", "childPrice", "infantPrice" };

                    foreach (string field in simpleFields)
                    {
                        AddSimpleElement(trainElement, field, trainData);
                    }
                }

                root.AppendChild(trainElement);

                // seatAvailability 섹션에도 새 열차 추가
                AddTrainToSeatAvailability(trainData["trainNumber"], trainData.ContainsKey("totalSeats") ? trainData["totalSeats"] : "400");

                xmlDoc.Save(xmlFilePath);

                MessageBox.Show("새 열차 정보가 추가되었습니다.", "추가 완료",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"열차 정보 추가 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTrainToSeatAvailability(string trainNumber, string totalSeats)
        {
            try
            {
                XmlNode seatAvailabilityNode = xmlDoc.GetElementsByTagName("seatAvailability")[0];
                if (seatAvailabilityNode == null)
                {
                    // seatAvailability 노드가 없으면 생성
                    seatAvailabilityNode = xmlDoc.CreateElement("seatAvailability");
                    xmlDoc.DocumentElement.AppendChild(seatAvailabilityNode);
                }

                XmlNodeList dateNodes = seatAvailabilityNode.SelectNodes("date");
                int defaultTotalSeats = int.TryParse(totalSeats, out int seats) ? seats : 400;

                foreach (XmlNode dateNode in dateNodes)
                {
                    // 각 날짜에 새 열차 추가
                    XmlElement newTrainElement = xmlDoc.CreateElement("train");
                    newTrainElement.SetAttribute("trainNumber", trainNumber);
                    newTrainElement.SetAttribute("availableSeats", defaultTotalSeats.ToString());
                    newTrainElement.SetAttribute("reservedSeats", "0");
                    dateNode.AppendChild(newTrainElement);
                }
            }
            catch (Exception ex)
            {
                // seatAvailability 추가 중 오류가 발생해도 열차 추가는 성공한 것으로 처리
                MessageBox.Show($"좌석 가용성 정보 추가 중 오류: {ex.Message}", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddSimpleElement(XmlElement parent, string elementName, Dictionary<string, string> data)
        {
            if (data.ContainsKey(elementName) && !string.IsNullOrWhiteSpace(data[elementName]) && elementName != "isComplexStructure")
            {
                XmlElement element = xmlDoc.CreateElement(elementName);
                element.InnerText = data[elementName];
                parent.AppendChild(element);
            }
        }

        private void UpdateTrainInXml(string trainNumberToUpdate, Dictionary<string, string> trainData)
        {
            try
            {
                XmlNodeList trainList = xmlDoc.GetElementsByTagName("train");
                string newTrainNumber = trainData["trainNumber"];
                bool trainNumberChanged = trainNumberToUpdate != newTrainNumber;
                bool trainFound = false;

                foreach (XmlNode train in trainList)
                {
                    string currentTrainNumber = GetNodeText(train, "trainNumber");
                    Console.WriteLine($"비교: '{currentTrainNumber}' vs '{trainNumberToUpdate}'"); // 디버깅

                    if (currentTrainNumber == trainNumberToUpdate)
                    {
                        trainFound = true;
                        Console.WriteLine("열차를 찾았습니다. 업데이트 시작..."); // 디버깅

                        foreach (var kvp in trainData)
                        {
                            if (kvp.Key == "isComplexStructure") continue; // 플래그는 건너뛰기

                            XmlNode node = train[kvp.Key];
                            if (node != null)
                            {
                                Console.WriteLine($"업데이트: {kvp.Key} = {kvp.Value}"); // 디버깅
                                node.InnerText = kvp.Value;
                            }
                            else
                            {
                                Console.WriteLine($"새 노드 생성: {kvp.Key} = {kvp.Value}"); // 디버깅
                                XmlElement newElement = xmlDoc.CreateElement(kvp.Key);
                                newElement.InnerText = kvp.Value;
                                train.AppendChild(newElement);
                            }
                        }
                        break;
                    }
                }

                if (!trainFound)
                {
                    MessageBox.Show($"열차번호 '{trainNumberToUpdate}'를 찾을 수 없습니다.", "오류");
                    return;
                }

                // 열차번호가 변경된 경우 seatAvailability도 업데이트
                if (trainNumberChanged)
                {
                    UpdateTrainNumberInSeatAvailability(trainNumberToUpdate, newTrainNumber);
                }

                xmlDoc.Save(xmlFilePath);
                MessageBox.Show("열차 정보가 수정되었습니다.", "수정 완료",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"열차 정보 수정 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTrainNumberInSeatAvailability(string oldTrainNumber, string newTrainNumber)
        {
            try
            {
                XmlNode seatAvailabilityNode = xmlDoc.GetElementsByTagName("seatAvailability")[0];
                if (seatAvailabilityNode == null) return;

                XmlNodeList dateNodes = seatAvailabilityNode.SelectNodes("date");

                foreach (XmlNode dateNode in dateNodes)
                {
                    XmlNodeList trainNodes = dateNode.SelectNodes($"train[@trainNumber='{oldTrainNumber}']");
                    foreach (XmlNode trainNode in trainNodes)
                    {
                        if (trainNode.Attributes["trainNumber"] != null)
                        {
                            trainNode.Attributes["trainNumber"].Value = newTrainNumber;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"좌석 가용성 정보 업데이트 중 오류: {ex.Message}", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteTrainFromXml(string trainNumberToDelete)
        {
            try
            {
                XmlNodeList trainList = xmlDoc.GetElementsByTagName("train");

                for (int i = trainList.Count - 1; i >= 0; i--)
                {
                    XmlNode train = trainList[i];
                    if (GetNodeText(train, "trainNumber") == trainNumberToDelete)
                    {
                        train.ParentNode.RemoveChild(train);
                        break;
                    }
                }

                // seatAvailability 섹션에서도 해당 열차 삭제
                RemoveTrainFromSeatAvailability(trainNumberToDelete);

                xmlDoc.Save(xmlFilePath);

                MessageBox.Show("열차 정보가 삭제되었습니다.", "삭제 완료",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"열차 정보 삭제 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveTrainFromSeatAvailability(string trainNumber)
        {
            try
            {
                XmlNode seatAvailabilityNode = xmlDoc.GetElementsByTagName("seatAvailability")[0];
                if (seatAvailabilityNode == null) return;

                XmlNodeList dateNodes = seatAvailabilityNode.SelectNodes("date");

                foreach (XmlNode dateNode in dateNodes)
                {
                    XmlNodeList trainNodes = dateNode.SelectNodes($"train[@trainNumber='{trainNumber}']");
                    for (int i = trainNodes.Count - 1; i >= 0; i--)
                    {
                        dateNode.RemoveChild(trainNodes[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                // seatAvailability 삭제 오류; 열차 삭제는 성공한 것으로 처리
                MessageBox.Show($"좌석 가용성 정보 삭제 중 오류: {ex.Message}", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}